using System;
using System.Collections.Generic;
using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;

namespace MiniatureGardenSound.Scripts.Provider
{

    public class NativeProvider : MonoBehaviour, INativeProvidable
    {
        [SerializeField] private AudioSource source;

        private int length;
        private int index;
        private List<byte> musicByte = new List<byte>();
        
        private Subject<Unit> changedMusic = new Subject<Unit>();
        public IObservable<Unit> ChangedMusic => changedMusic;
        
        public void Injection(AudioSource source)
        {
            this.source = source;
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
            source.clip = WavUtility.ToAudioClip(musicByte.ToArray());
            source.Play();
            changedMusic.OnNext(Unit.Default);
        }
    }
}