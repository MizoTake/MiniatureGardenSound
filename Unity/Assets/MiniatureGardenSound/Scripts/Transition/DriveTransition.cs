using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Transition.Interface;
using Zenject;

namespace MiniatureGardenSound.Transition
{
    public class DriveTransition : ISceneTransitionable, IInitializable
    {

        [Inject]
        private void Injection()
        {
            
        }
        
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
        
        public UniTask Show()
        {
            throw new System.NotImplementedException();
        }

        public UniTask Hide()
        {
            return UniTask.CompletedTask;
        }
    }
}