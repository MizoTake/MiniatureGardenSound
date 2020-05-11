using UnityEngine;

namespace MiniatureGardenSound.Component
{
    public class ScreenAspectCamera : MonoBehaviour
    {
        void Update()
        {
            var hegihtPer = (float)Screen.height / (float)Screen.width;
            var per = Mathf.Clamp01(hegihtPer);
            var nextY = Mathf.Lerp(0f, 14f, per);
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, nextY, localPosition.z);
            transform.localPosition = localPosition;
        }
    }
}
