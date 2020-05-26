using System;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using MiniatureGardenSound.Manager.Interface;
using MiniatureGardenSound.Scene;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Zenject;
using SceneManager = UnityEditor.SceneManagement.EditorSceneManager;

namespace MiniatureGardenSound.Editor
{
    public class EditorSceneManager : ISceneManagable
    {
        public UniTask AddingAsync(Scenes scene, Action<DiContainer> extraBindings = null)
        {
            var sceneAsset = GetScenes(scene.ToString());
            if (sceneAsset == null)
            {
                Debug.LogWarning("Scene Load Warrning : Loaded Scene");
                return UniTask.CompletedTask;
            }
            SceneManager.OpenScene(AssetDatabase.GetAssetPath(sceneAsset), OpenSceneMode.Additive);
            return UniTask.CompletedTask;
        }

        public UniTask RemoveAsync(Scenes scene)
        {
            var isSharedMainExists = false;
            var scenePath = "";
            for (var index = 0; index < SceneManager.sceneCount; index++)
            {
                var sceneAt = SceneManager.GetSceneAt(index);
                isSharedMainExists = sceneAt.isLoaded && sceneAt.name == scene.ToString();
                scenePath = sceneAt.path;
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
