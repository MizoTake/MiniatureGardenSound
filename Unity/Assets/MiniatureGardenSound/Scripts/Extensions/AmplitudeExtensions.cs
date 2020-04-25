using CrazyMinnow.AmplitudeWebGL;

namespace MiniatureGardenSound.Scripts.Extensions
{
    public static class AmplitudeExtensions
    {
                
        public static void Setup(this Amplitude amplitude) 
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Amplitude.WebGL_StartSampling(amplitude.audioSource.GetInstanceID().ToString(), amplitude.audioSource.clip.length, amplitude.sampleSize, amplitude.dataType.ToString());
#endif
            amplitude.prevPlayState = amplitude.audioSource.isPlaying;
        }
    }
}