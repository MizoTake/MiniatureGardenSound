using Cysharp.Threading.Tasks;

namespace MiniatureGardenSound.Transition.Interface
{
    public interface ISceneTransitionable
    {
        UniTask Show();
        UniTask Hide();
    }
}