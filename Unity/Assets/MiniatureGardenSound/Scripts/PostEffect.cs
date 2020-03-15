using UnityEngine;

namespace MiniatureGardenSound.Scripts
{
    public class PostEffect : MonoBehaviour
    {
        public Material monoTone;
        [Range(0, 1)] public float value;

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            monoTone.SetFloat("_Value", value);
            Graphics.Blit(src, dest, monoTone);
        }
    }
}