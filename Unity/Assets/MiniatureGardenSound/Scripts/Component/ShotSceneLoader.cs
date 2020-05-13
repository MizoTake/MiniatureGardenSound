using MiniatureGardenSound.Manager;
using MiniatureGardenSound.Manager.Interface;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Component
{
    public class ShotSceneLoader : MonoBehaviour
    {

        [SerializeField] private SceneObject firstAddingScene;

        private ISceneManagable sceneManager;

        [Inject]
        private void Injection(ISceneManagable sceneManager)
        {
            this.sceneManager = sceneManager;
        }
        
        async void Start()
        {
            await sceneManager.AddingAsync(firstAddingScene);
        }
    }
}
