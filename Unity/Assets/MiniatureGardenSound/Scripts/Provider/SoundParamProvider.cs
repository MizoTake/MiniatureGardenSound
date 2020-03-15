using System.Linq;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Provider
{
    public class SoundParamProvider : IInitializable, ITickable, ISoundParamProvider
    {

        private AudioSource source;
        private INativeProvidable nativeProvider;
        private float[] spec = new float[1024];

        private float currentMusicTime;
        
        public float Time { get; private set; }
        public float Power { get; private set; }
        public float Amp { get; } = 10.0f;

        [Inject]
        private void Injection(AudioSource source, INativeProvidable nativeProvider)
        {
            this.source = source;
            this.nativeProvider = nativeProvider;
        }
        
        public void Initialize()
        {
            ChangedMusic();
            nativeProvider.ChangedMusic
                .TakeUntilDestroy(source)
                .Subscribe(x =>
                {
                    ChangedMusic();
                });
        }

        private void ChangedMusic()
        {
            currentMusicTime = source.time;
            Random.InitState((int) currentMusicTime);
        }

        public void Tick()
        {
            source.GetSpectrumData(spec, 0, FFTWindow.Hamming);

            Time = source.time;
            Power = spec.Sum();
        }
    }
}
