using MiniatureGardenSound.Scripts.Transition.Interface;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Transition
{
    public class RainTransition : MonoBehaviour, ITransitionable
    {

        [SerializeField] private GameObject[] activeOrder;

        private MusicUnity musicUnity;

        [Inject]
        private void Injection(MusicUnity musicUnity)
        {
            this.musicUnity = musicUnity;
        }

        private void Awake()
        {
            foreach (var obj in activeOrder)
            {
                obj.SetActive(false);
            }
        }

        public async UniTask Enable()
        {
            Debug.Log("enable");
            var index = 0;
            while (index != activeOrder.Length)
            {
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBeat());
                activeOrder[index].SetActive(true);
                index += 1;
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBeat() == false);
            }
        }

        public UniTask Disable()
        {
            Debug.Log("Disable");
            return UniTask.CompletedTask;
        }
    }
}
