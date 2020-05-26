using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Transition.Abstract;
using MiniatureGardenSound.Transition.Interface;

namespace MiniatureGardenSound.Transition
{
    public class DriveTransition : BaseTransition, ISceneTransitionable
    {

        public async UniTask Show()
        {
            await CommonShowing();
        }

        public UniTask Hide()
        {
            return UniTask.CompletedTask;
        }
    }
}