using System;
using System.Collections.Generic;
using CrazyMinnow.AmplitudeWebGL;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Provider
{

    public class NativeProvider : MonoBehaviour, INativeProvidable
    {
        private Amplitude amplitude;

        private int length;
        private int index;
        private List<byte> musicByte = new List<byte>();
        
        private Subject<Unit> changedMusic = new Subject<Unit>();
        public IObservable<Unit> ChangedMusic => changedMusic;
        
        [Inject]
        public void Injection(Amplitude amplitude)
        {
            this.amplitude = amplitude;
        }

        public void MusicLength(int length)
        {
            this.length = length;
            index = 0;
            musicByte.Clear();
        }

        public void DropMusic(string byteString)
        {
            var decode = Convert.FromBase64String(byteString);
            musicByte.AddRange(decode);
            index += 1;
            if (length != index) return;
            UpdateMusic();
        }

        private void UpdateMusic()
        {
            amplitude.audioSource.Stop();
            amplitude.audioSource.clip = WavUtility.ToAudioClip(musicByte.ToArray());
            changedMusic.OnNext(Unit.Default);
        }
    }
}