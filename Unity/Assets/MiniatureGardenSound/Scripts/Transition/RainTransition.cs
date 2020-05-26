using Cysharp.Threading.Tasks;
using DG.Tweening;
using MiniatureGardenSound.Provider.Interface;
using MiniatureGardenSound.Transition.Interface;
using Zenject;

namespace MiniatureGardenSound.Transition
{
    public class RainTransition : ISceneTransitionable, IInitializable
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

        public async UniTask Show()
        {
            await parameterProvidable.FadeImage.DOFade(0, 0.1f);
            
            var index = 0;
            while (index != parameterProvidable.ActiveOrder.Length)
            {
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBar());
                parameterProvidable.ActiveOrder[index].SetActive(true);
                index += 1;
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBar() == false);
            }
        }

        public UniTask Hide()
        {
            return UniTask.CompletedTask;
        }
    }
}
