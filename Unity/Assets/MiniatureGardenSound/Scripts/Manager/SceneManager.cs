using System.Linq;
using ModestTree;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace MiniatureGardenSound.Scripts.Manager
{
    public static class SceneManager
    {
        
        public static async UniTask AddingAsync(SceneObject addScene)
        {
#if UNITY_EDITOR
            var scenePath = EditorBuildSettings.scenes.Select(x => x.path).FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == addScene) ?? "";
            if (scenePath.IsEmpty())
            {
                Debug.LogWarning("Scene Load Warrning : Loaded Scene");
                return;
            }
            if (Application.isEditor)
            {
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
                return;
            }
#endif
            await UniSceneManager.LoadSceneAsync(addScene, LoadSceneMode.Additive);
            // transitionのコール
            
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
    }
}
