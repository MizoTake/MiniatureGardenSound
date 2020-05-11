using UnityEngine;

namespace MiniatureGardenSound.Component
{
    public static class CameraAccessor
    {

        private static Camera mainCamera;
        public static Camera MainCamera
        {
            get
            {
                if (mainCamera == null) mainCamera = Camera.main;
                return mainCamera;
            }
        }
        
    }
}
