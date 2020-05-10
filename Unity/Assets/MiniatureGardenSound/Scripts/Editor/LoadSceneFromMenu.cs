using UniRx.Async;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniatureGardenSound.Scripts.Editor
{
    public class LoadSceneFromMenu
    {

        private const string SharedMain = "SharedMain";
        
        [MenuItem("MiniatureGardenSound/SharedMain")]
        private static async void LoadSharedMain()
        {
            await Manager.SceneManager.AddingAsync(SharedMain);
        }
    }
}
