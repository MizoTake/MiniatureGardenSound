using System.Linq;
using CrazyMinnow.AmplitudeWebGL;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Provider
{
    public class SoundParamProvider : IInitializable, ITickable, ISoundParamProvider
    {

        private INativeProvidable nativeProvider;
        private Amplitude amplitude;

        private float currentMusicTime;
        
        public float Time { get; private set; }
        public float Power { get; private set; }
        public float Amp { get; } = 8.0f;

        [Inject]
        private void Injection(Amplitude amplitude, INativeProvidable nativeProvider)
        {
            this.nativeProvider = nativeProvider;
            this.amplitude = amplitude;
        }
        
        public void Initialize()
        {
            ChangedMusic();
            nativeProvider.ChangedMusic
                .TakeUntilDestroy(amplitude.audioSource)
                .Subscribe(x =>
                {
                    ChangedMusic();
                });
        }

        private void ChangedMusic()
        {
            currentMusicTime = amplitude.audioSource.time;
            Random.InitState((int) currentMusicTime);
            // amplitude.Setup();
            amplitude.audioSource.Play();
        }

        public void Tick()
        {
            Time = amplitude.audioSource.time;
            Power = amplitude.sample.Sum() / 15f;
        }
    }
}
