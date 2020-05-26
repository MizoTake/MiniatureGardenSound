using System;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Scene;
using Zenject;

namespace MiniatureGardenSound.Manager.Interface
{
    public interface ISceneManagable
    {
        UniTask AddingAsync(Scenes scene, Action<DiContainer> extraBindings = null);
        UniTask RemoveAsync(Scenes scene);
    }
}