namespace MiniatureGardenSound.Provider.Interface
{
    public interface IParameterThresholdProvider
    {
        float WaitRequest { get; }
        (float, float) WaitTime { get; }
        (float, float) UmbrellaMoveTime { get; }
        (float, float) RotateTime { get; }
        float NoiseRange { get; }
    }
}