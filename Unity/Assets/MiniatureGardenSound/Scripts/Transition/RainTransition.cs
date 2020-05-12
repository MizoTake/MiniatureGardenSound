using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Provider.Interface;
using MiniatureGardenSound.Transition.Interface;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Transition
{
    public class RainTransition : ITransitionable, IInitializable
    {

        private MusicUnity musicUnity;
        private ITransitionParameterProvidable parameterProvidable;

        [Inject]
        private void Injection(MusicUnity musicUnity, ITransitionParameterProvidable parameterProvidable)
        {
            this.musicUnity = musicUnity;
            this.parameterProvidable = parameterProvidable;
        }
        
        public void Initialize()
        {
            foreach (var obj in parameterProvidable.ActiveOrder)
            {
                obj.SetActive(false);
            }
        }

        public async UniTask Enable()
        {
            Debug.Log("enable");
            var index = 0;
            while (index != parameterProvidable.ActiveOrder.Length)
            {
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBeat());
                parameterProvidable.ActiveOrder[index].SetActive(true);
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
