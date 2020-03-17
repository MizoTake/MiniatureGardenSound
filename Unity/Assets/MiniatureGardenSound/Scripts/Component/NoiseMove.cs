using System;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Component
{
    public class NoiseMove : MonoBehaviour
    {
        [Range(0, 5), SerializeField] private float NoiseSpeed = 0.5f;
        [Range(0, 5), SerializeField] public float NoiseCoeff = 1.3f;

        private Vector3 defaultRot;
        private ISoundParamProvider soundProvider;
        private IParameterThresholdProvider thresholdProvider;

        [Inject]
        private void Inject(ISoundParamProvider soundProvider, IParameterThresholdProvider thresholdProvider)
        {
            this.soundProvider = soundProvider;
            this.thresholdProvider = thresholdProvider;
        }

        private void Start()
        {
            defaultRot = transform.rotation.eulerAngles;
        }

        void Update()
        {
            var t = soundProvider.Time * NoiseSpeed;
            var range = thresholdProvider.NoiseRange;
            var coeff = NoiseCoeff;
            var noiseX = Mathf.PerlinNoise(t, t) * coeff;
            var noiseY = Mathf.PerlinNoise(t + range, t + range) * coeff;
            var noiseZ = Mathf.PerlinNoise(t + range, t + range) * coeff;
            var noise = new Vector3(noiseX, noiseY, noiseZ);

            var noiseRot = Quaternion.Euler(defaultRot.x + noise.x, defaultRot.y + noise.y, defaultRot.z + noise.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, noiseRot, Time.deltaTime);
        }
    }
}