using UnityEngine;

namespace MiniatureGardenSound.Data
{
    [CreateAssetMenu(menuName="MiniatureGardenSound/SceneConstitution", fileName="SceneConstitution")]
    public class SceneConstitution : ScriptableObject
    {
        public SceneObject mainScene;
        public SceneObject backgroundScene;
    }
}
