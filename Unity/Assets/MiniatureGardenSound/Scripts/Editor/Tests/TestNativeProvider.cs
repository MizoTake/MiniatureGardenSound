using MiniatureGardenSound.Scripts.Provider;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestNativeProvider
    {
        [Test]
        public void TestNativeProviderChangeMusic()
        {
            var mockMusic = Resources.Load<TextAsset>("MockMusic").text;
            var gameObject = new GameObject();
            var audioSource = gameObject.AddComponent<AudioSource>();
            var provider = gameObject.AddComponent<NativeProvider>();
            provider.Injection(audioSource);
            var splitLength = 10000;
            var len = mockMusic.Length / splitLength;
            provider.MusicLength(len + 1);
            for (var i = 0; i < len; i++)
            {
                var next = mockMusic.Substring(splitLength * i, splitLength);
                provider.DropMusic(next);
            }
            var last = mockMusic.Substring(splitLength * (len - 1), mockMusic.Length % splitLength);
            provider.DropMusic(last);
        }
    }
}
