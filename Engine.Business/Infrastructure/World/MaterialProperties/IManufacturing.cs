namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IManufacturing
    {
        float GetCastability();
        float GetMachinability();
        float GetMachiningSpeedCoefficient();
        float GetMachiningFeedCoefficient();
    }
}
