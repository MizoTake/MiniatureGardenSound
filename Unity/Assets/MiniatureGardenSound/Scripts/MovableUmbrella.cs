using System;
using DG.Tweening;
using MiniatureGardenSound.Scripts.Extensions;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace MiniatureGardenSound.Scripts
{
    public class MovableUmbrella : MonoBehaviour
    {
        [Inject(Id = "Left")] private Transform[] leftUmbrellas;
        [Inject(Id = "Right")] private Transform[] rightUmbrellas;
        private NavMeshAgent agent;
        private float moveTime;
        private Vector3 begin;
        private Vector3 end;
        private bool isBeginLeftSide;
        private ISoundParamProvider soundProvider;
        private IParameterThresholdProvider thresholdProvider;
        private Subject<State> stateSubject = new Subject<State>();

        public IObservable<State> StateAsObservable => stateSubject;
        public bool IsWait { get; set; }

        public enum State
        {
            Wait,
            Move
        }

        [Inject]
        private void Inject(ISoundParamProvider soundProvider, IParameterThresholdProvider thresholdProvider)
        {
            this.soundProvider = soundProvider;
            this.thresholdProvider = thresholdProvider;
        }

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            ChangeMoveTime();
            isBeginLeftSide = transform.position.x > 0;
            DecidePoint();
            var (begin, end) = thresholdProvider.RotateTime;
            var time = Random.Range(begin, end);
            transform.DORotate(new Vector3(0f, 360f), time, RotateMode.FastBeyond360).SetLoops(-1).Play();
//            transform.DOScale(Vector3.one * Random.Range(1f, 1.3f), time).SetLoops(-1).Play();
        }

        async void Update()
        {
            await WaitIfNeed();
//            agent.speed *= moveTime * Time.deltaTime;
            if (!(agent.remainingDistance < agent.radius)) return;
            stateSubject.OnNext(State.Wait);
            isBeginLeftSide = isBeginLeftSide.Toggle();
            DecidePoint();
            ChangeMoveTime();
            stateSubject.OnNext(State.Move);
        }

        private void DecidePoint()
        {
            var beginArray = isBeginLeftSide ? leftUmbrellas : rightUmbrellas;
            var index = Random.Range(0, beginArray.Length);
            begin = beginArray[index].position;

            var endArray = isBeginLeftSide ? rightUmbrellas : leftUmbrellas;
            index = Random.Range(0, endArray.Length);
            end = endArray[index].position;

            agent.SetDestination(end);
        }

        private async UniTask WaitIfNeed()
        {
            if (IsWait)
            {
                var (begin, end) = thresholdProvider.WaitTime;
                var waitTime = Random.Range(begin, end);
                var navSpeed = agent.speed;
                agent.speed = 0f;
                await UniTask.Delay(TimeSpan.FromSeconds(waitTime));
                agent.speed = navSpeed;
                IsWait = false;
            }
        }

        private void ChangeMoveTime()
        {
            var (begin, end) = thresholdProvider.UmbrellaMoveTime;
            moveTime = Random.Range(begin, end);
        }
    }
}