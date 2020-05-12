using Cysharp.Threading.Tasks;

namespace MiniatureGardenSound.Transition.Interface
{
    public interface ITransitionable
    {
        UniTask Enable();
        UniTask Disable();
    }
}