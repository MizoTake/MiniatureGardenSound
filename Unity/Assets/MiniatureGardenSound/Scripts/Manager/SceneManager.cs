using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace MiniatureGardenSound.Manager
{
    public static class SceneManager
    {
        public static async UniTask AddingAsync(SceneObject addScene)
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
            await UniSceneManager.LoadSceneAsync(addScene, LoadSceneMode.Additive);
        }

        public static async UniTask RemoveAsync(SceneObject removeScene)
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
        private static IEnumerable<string> GetScenes()
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
