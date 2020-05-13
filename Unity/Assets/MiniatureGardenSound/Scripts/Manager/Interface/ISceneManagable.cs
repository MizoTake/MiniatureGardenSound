using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiniatureGardenSound.Manager.Interface
{
    public interface ISceneManagable
    {
        UniTask AddingAsync(SceneObject addScene, Action<DiContainer> extraBindings = null);
        UniTask RemoveAsync(SceneObject removeScene);
    }
}