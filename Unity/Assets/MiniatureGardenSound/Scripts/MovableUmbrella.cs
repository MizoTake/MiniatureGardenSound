using System;
using DG.Tweening;
using MiniatureGardenSound.Scripts.Extensions;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace MiniatureGardenSound.Scripts
{
    public class MovableUmbrella : MonoBehaviour
    {
        [Inject(Id = "Left")]
        private Transform[] leftUmbrellas;
        [Inject(Id = "Right")]
        private Transform[] rightUmbrellas;
        private NavMeshAgent agent;
        private float moveTime;
        private Vector3 begin;
        private Vector3 end;
        private bool isBeginLeftSide;
        private ISoundParamProvider soundProvider;
        private Subject<State> stateSubject = new Subject<State>();

        public IObservable<State> StateAsObservable => stateSubject;

        public enum State
        {
            Wait,
            Move
        }

        [Inject]
        private void Inject(ISoundParamProvider soundProvider)
        {
            this.soundProvider = soundProvider;
        }

        void Start ()
        {
            agent = GetComponent<NavMeshAgent> ();
            ChangeMoveTime ();
            isBeginLeftSide = transform.position.x > 0;
            DecidePoint ();
            var time = Random.Range (4.0f, 6.0f);
            transform.DORotate (new Vector3 (0f, 360f), time, RotateMode.FastBeyond360).SetLoops (-1).Play ();
        }

        void Update ()
        {
//            agent.speed *= moveTime * Time.deltaTime;
            if (!(agent.remainingDistance < agent.radius)) return;
            stateSubject.OnNext(State.Wait);
            isBeginLeftSide = isBeginLeftSide.Toggle ();
            DecidePoint ();
            ChangeMoveTime ();
            stateSubject.OnNext(State.Move);
        }

        private void DecidePoint ()
        {
            var beginArray = isBeginLeftSide ? leftUmbrellas : rightUmbrellas;
            var index = Random.Range(0, beginArray.Length);
            begin = beginArray[index].position;
        
            var endArray = isBeginLeftSide ?  rightUmbrellas : leftUmbrellas;
            index = Random.Range(0, endArray.Length);
            end = endArray[index].position;

            agent.SetDestination(end);
        }

        private void ChangeMoveTime ()
        {
            moveTime = Random.Range (10f, 16f);
        }
    }
}