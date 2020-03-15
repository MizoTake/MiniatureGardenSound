using MiniatureGardenSound.Scripts.Provider.Interface;
using UnityEngine;

namespace MiniatureGardenSound.Scripts.Provider
{
    public class ParameterThresholdProvider : MonoBehaviour, IParameterThresholdProvider
    {
        [Range(0f, 1f), SerializeField] private float waitRequest = 0.3f;
        [Range(0f, 100f), SerializeField] private float waitTimeBegin = 0.5f;
        [Range(0f, 100f), SerializeField] private float waitTimeEnd = 2f;
        [Range(0f, 100f), SerializeField] private float umbrellaMoveTimeBegin = 10f;
        [Range(0f, 100f), SerializeField] private float umbrellaMoveTimeEnd = 16f;
        [Range(0f, 100f), SerializeField] private float rotateTimeBegin = 4f;
        [Range(0f, 100f), SerializeField] private float rotateTimeEnd = 6f;

        public float WaitRequest => waitRequest;
        public (float, float) WaitTime => (waitTimeBegin, waitTimeEnd);
        public (float, float) UmbrellaMoveTime => (umbrellaMoveTimeBegin, umbrellaMoveTimeEnd);
        public (float, float) RotateTime => (rotateTimeBegin, rotateTimeEnd);
    }
}
