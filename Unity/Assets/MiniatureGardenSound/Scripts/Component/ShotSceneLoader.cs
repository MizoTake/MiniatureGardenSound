using MiniatureGardenSound.Manager;
using UnityEngine;

namespace MiniatureGardenSound.Component
{
    public class ShotSceneLoader : MonoBehaviour
    {

        [SerializeField] private SceneObject firstAddingScene;
        
        async void Start()
        {
            await SceneManager.AddingAsync(firstAddingScene);
        }
    }
}
