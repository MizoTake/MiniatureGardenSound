using MiniatureGardenSound.Confiig;
using MiniatureGardenSound.Editor;
using MiniatureGardenSound.Scene;
using UnityEditor;

namespace MiniatureGardenSound.Scripts.Editor
{
    public class LoadSceneFromMenu
    {
        [MenuItem(Define.MENU_NAME+"/SharedMain")]
        private static async void LoadSharedMain()
        {
            var sceneManager = new EditorSceneManager();
            await sceneManager.AddingAsync(Scenes.SharedMain);
        }
    }
}
