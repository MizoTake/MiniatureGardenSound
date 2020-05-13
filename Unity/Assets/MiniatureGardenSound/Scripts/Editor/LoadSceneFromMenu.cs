using MiniatureGardenSound.Editor;
using MiniatureGardenSound.Manager;
using UnityEditor;

namespace MiniatureGardenSound.Scripts.Editor
{
    public class LoadSceneFromMenu
    {

        private const string SharedMain = "SharedMain";
        
        [MenuItem("MiniatureGardenSound/SharedMain")]
        private static async void LoadSharedMain()
        {
            var sceneManager = new EditorSceneManager();
            await sceneManager.AddingAsync(SharedMain);
        }
    }
}
