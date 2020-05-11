
namespace MiniatureGardenSound.Provider.Interface
{
    public interface ISoundParamProvider
    {
        float Time { get; }
        float Power { get; }
        float Amp { get; }
        bool IsJustChangedBeat { get; }
    }
}
