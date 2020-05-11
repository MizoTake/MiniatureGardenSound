using UniRx.Async;

namespace MiniatureGardenSound.Transition.Interface
{
    public interface ITransitionable
    {
        UniTask Enable();
        UniTask Disable();
    }
}