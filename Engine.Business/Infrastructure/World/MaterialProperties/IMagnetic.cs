namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IMagnetic
    {
        float GetCurieTemperature();
        float GetDiamagnetism();
        float GetHysteresis();
        float GetPermeability();
        float GetMagnetostriction();
    }
}
