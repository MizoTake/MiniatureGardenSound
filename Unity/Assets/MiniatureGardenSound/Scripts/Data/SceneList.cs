using System;
using MiniatureGardenSound.Confiig;
using MiniatureGardenSound.Scene;
using UnityEngine;

namespace MiniatureGardenSound.Data
{

    [CreateAssetMenu(menuName=Define.MENU_NAME+"/SceneList", fileName="SceneList")]
    public class SceneList : ScriptableObject
    {
        [SerializeField] private SceneConstitution sharedMain;
        [SerializeField] private SceneConstitution rain;
        [SerializeField] private SceneConstitution drive;

        public SceneConstitution SharedMain => sharedMain;
        public SceneConstitution Rain => rain;
        public SceneConstitution Drive => drive;

        public SceneConstitution Get(Scenes scene)
        {
            switch (scene)
            {
                case Scenes.SharedMain:
                    return sharedMain;
                case Scenes.Rain:
                    return rain;
                case Scenes.Drive:
                    return drive;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scene), scene, null);
            }
        } 
    }
}