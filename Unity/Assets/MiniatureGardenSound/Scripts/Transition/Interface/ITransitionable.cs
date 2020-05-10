using UniRx.Async;

namespace MiniatureGardenSound.Scripts.Transition.Interface
{
    public interface ITransitionable
    {
        UniTask Enable();
        UniTask Disable();
    }
}