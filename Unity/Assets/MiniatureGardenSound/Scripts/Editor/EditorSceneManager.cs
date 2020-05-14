using System;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Manager.Interface;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Zenject;
using SceneManager = UnityEditor.SceneManagement.EditorSceneManager;

namespace MiniatureGardenSound.Editor
{
    public class EditorSceneManager : ISceneManagable
    {
        public UniTask AddingAsync(SceneObject addScene, Action<DiContainer> extraBindings = null)
        {
            var sceneAsset = GetScenes(addScene);
            if (sceneAsset == null)
            {
                Debug.LogWarning("Scene Load Warrning : Loaded Scene");
                return UniTask.CompletedTask;
            }
            SceneManager.OpenScene(AssetDatabase.GetAssetPath(sceneAsset), OpenSceneMode.Additive);
            return UniTask.CompletedTask;
        }

        public UniTask RemoveAsync(SceneObject removeScene)
        {
            var isSharedMainExists = false;
            var scenePath = "";
            for (var index = 0; index < SceneManager.sceneCount; index++)
            {
                var scene = SceneManager.GetSceneAt(index);
                isSharedMainExists = scene.isLoaded && scene.name == removeScene;
                scenePath = scene.path;
            }
            if (!isSharedMainExists) return UniTask.CompletedTask;
            SceneManager.UnloadSceneAsync(scenePath);
            return UniTask.CompletedTask;
        }
        
        private SceneAsset GetScenes(string target)
        {
            return AssetDatabase.FindAssets("t:SceneAsset")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(path => AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)))
                .Where(obj => obj != null)
                .Select(obj => (SceneAsset) obj)
                .FirstOrDefault(asset => Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(asset)) == target);
        }
    }
}
