using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Manager.Interface;
using ModestTree;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace MiniatureGardenSound.Manager
{
    public class SceneManager : ISceneManagable
    {

        private ZenjectSceneLoader sceneLoader;
        
#if UNITY_EDITOR
        public SceneManager()
        {
            
        }
#endif
        
        SceneManager(ZenjectSceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public async UniTask AddingAsync(SceneObject addScene, Action<DiContainer> extraBindings = null)
        {
#if UNITY_EDITOR
            var scenePath = GetScenes().FirstOrDefault(x => x == addScene) ?? "";
            if (scenePath.IsEmpty())
            {
                Debug.LogWarning("Scene Load Warrning : Loaded Scene");
                return;
            }
            if (!Application.isPlaying)
            {
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
                return;
            }
#endif
            await sceneLoader.LoadSceneAsync(addScene, LoadSceneMode.Additive, extraBindings);
        }

        public async UniTask RemoveAsync(SceneObject removeScene)
        {
#if UNITY_EDITOR
            var isSharedMainExists = false;
            var scenePath = "";
            for (var index = 0; index < EditorSceneManager.sceneCount; index++)
            {
                var scene = EditorSceneManager.GetSceneAt(index);
                isSharedMainExists = scene.isLoaded && scene.name == removeScene;
                scenePath = scene.path;
            }
            if (!isSharedMainExists) return;
            if (Application.isEditor)
            {
                EditorSceneManager.UnloadSceneAsync(scenePath);
                return;
            }
#endif
            await UniSceneManager.UnloadSceneAsync(removeScene);
        }
        
#if UNITY_EDITOR
        private IEnumerable<string> GetScenes()
        {
            return AssetDatabase.FindAssets("t:SceneAsset")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(path => AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)))
                .Where(obj => obj != null)
                .Select(obj => (SceneAsset) obj)
                .Select(asset => Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(asset)));
        }
#endif
    }
}
