using System;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Data;
using MiniatureGardenSound.Extensions;
using MiniatureGardenSound.Manager.Interface;
using MiniatureGardenSound.Scene;
using UnityEngine.SceneManagement;
using Zenject;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;

namespace MiniatureGardenSound.Manager
{
    public class SceneManager : ISceneManagable
    {

        private ZenjectSceneLoader sceneLoader;
        private SceneList list;

        SceneManager(ZenjectSceneLoader sceneLoader, SceneList list)
        {
            this.sceneLoader = sceneLoader;
            this.list = list;
        }

        public async UniTask AddingAsync(Scenes scene, Action<DiContainer> extraBindings = null)
        {
            var sceneData = list.Get(scene);
            await UniTask.SwitchToMainThread();
            await sceneLoader.LoadSceneAsync(sceneData.mainScene, LoadSceneMode.Additive, extraBindings);
            if (!sceneData.backgroundScene.IsEmpty())
            {
                await sceneLoader.LoadSceneAsync(sceneData.backgroundScene, LoadSceneMode.Additive, extraBindings);
            }
        }

        public async UniTask RemoveAsync(Scenes scene)
        {
            var sceneData = list.Get(scene);
            await UniSceneManager.UnloadSceneAsync(sceneData.mainScene);
            if (sceneData.backgroundScene != null)
            {
                await UniSceneManager.UnloadSceneAsync(sceneData.backgroundScene);
            }
        }
    }
}
