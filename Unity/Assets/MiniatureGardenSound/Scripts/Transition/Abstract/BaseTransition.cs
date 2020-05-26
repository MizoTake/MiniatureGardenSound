using Cysharp.Threading.Tasks;
using DG.Tweening;
using MiniatureGardenSound.Provider.Interface;
using Zenject;

namespace MiniatureGardenSound.Transition.Abstract
{
    public abstract class BaseTransition : IInitializable
    {
        
        protected MusicUnity musicUnity;
        protected ITransitionParameterProvidable parameterProvidable;

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

        protected async UniTask CommonShowing()
        {
            await parameterProvidable.FadeImage.DOFade(0, 0.1f);
            
            var index = 0;
            while (index != parameterProvidable.ActiveOrder.Length)
            {
                await UniTask.WaitWhile(musicUnity.IsJustChangedBar);
                parameterProvidable.ActiveOrder[index].SetActive(true);
                index += 1;
                await UniTask.WaitWhile(() => musicUnity.IsJustChangedBar() == false);
            }
        }
    }
}