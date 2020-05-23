using MiniatureGardenSound.Provider.Interface;

namespace MiniatureGardenSound.Provider.Dummy
{
    public class DummySoundParamProvider : ISoundParamProvider
    {
        public float Time => UnityEngine.Time.deltaTime;
        public float Power => 0f;
        public float Amp => 1f;
        public bool IsJustChangedBeat => false;
    }
}
