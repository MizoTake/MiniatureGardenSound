using System.Linq;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Provider
{
    public class SoundParamProvider : ITickable, ISoundParamProvider
    {

        private AudioSource source;
        private float[] spec = new float[1024];
        
        public float Time { get; private set; }
        public float Power { get; private set; }
        public float Amp { get; } = 10.0f;

        [Inject]
        private void Injection(AudioSource source)
        {
            this.source = source;
        }

        public void Tick()
        {
            source.GetSpectrumData(spec, 0, FFTWindow.Hamming);

            Time = source.time;
            Power = spec.Sum();
        }
    }
}
