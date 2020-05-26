using MiniatureGardenSound.Manager.Interface;
using MiniatureGardenSound.Scene;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Component
{
    public class ShotSceneLoader : MonoBehaviour
    {

        [SerializeField] private Scenes scene;

        private ISceneManagable sceneManager;

        [Inject]
        private void Injection(ISceneManagable sceneManager)
        {
            this.sceneManager = sceneManager;
        }
        
        async void Start()
        {
            await sceneManager.AddingAsync(scene);
        }
    }
}
