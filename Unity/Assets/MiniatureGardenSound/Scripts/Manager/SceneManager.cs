using UniRx.Async;
using UnityEngine.SceneManagement;
using UniSceneManager = UnityEngine.SceneManagement.SceneManager;

namespace MiniatureGardenSound.Scripts.Manager
{
    public class SceneManager
    {
        public async UniTask AddingAsync(SceneObject addScene)
        {
            await UniSceneManager.LoadSceneAsync(addScene, LoadSceneMode.Additive);
        }

        public async UniTask RemoveAsync(SceneObject removeScene)
        {
            await UniSceneManager.UnloadSceneAsync(removeScene);
        }
    }
}
