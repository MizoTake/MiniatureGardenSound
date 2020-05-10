using MiniatureGardenSound.Scripts.Manager;
using UniRx.Async;
using UnityEngine;

namespace MiniatureGardenSound.Scripts.Component
{
    public class ShotSceneLoader : MonoBehaviour
    {

        [SerializeField] private SceneObject firstAddingScene;
        
        void Start()
        {
            SceneManager.AddingAsync(firstAddingScene).Forget();
        }
    }
}
