using System;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Manager.Interface;
using UnityEngine.SceneManagement;
using Zenject;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;

namespace MiniatureGardenSound.Manager
{
    public class SceneManager : ISceneManagable
    {

        private ZenjectSceneLoader sceneLoader;

        SceneManager(ZenjectSceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public async UniTask AddingAsync(SceneObject addScene, Action<DiContainer> extraBindings = null)
        {
            await UniTask.SwitchToMainThread();
            await sceneLoader.LoadSceneAsync(addScene, LoadSceneMode.Additive, extraBindings);
        }

        public async UniTask RemoveAsync(SceneObject removeScene)
        {
            await UniSceneManager.UnloadSceneAsync(removeScene);
        }
    }
}
