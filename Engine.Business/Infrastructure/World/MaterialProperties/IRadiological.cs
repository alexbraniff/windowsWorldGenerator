namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IRadiological
    {
        float GetNeutronCrossSection();
        float GetSpecificActivity();
    }
}
