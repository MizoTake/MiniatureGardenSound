using MiniatureGardenSound.Confiig;
using UnityEngine;

namespace MiniatureGardenSound.Data
{
    [CreateAssetMenu(menuName=Define.MENU_NAME+"/SceneConstitution", fileName="SceneConstitution")]
    public class SceneConstitution : ScriptableObject
    {
        public SceneObject mainScene;
        public SceneObject backgroundScene;
    }
}
