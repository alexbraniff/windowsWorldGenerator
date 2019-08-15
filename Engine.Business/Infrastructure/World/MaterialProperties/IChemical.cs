namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IChemical
    {
        float GetCorrosionResistance();
        float GetHygroscopy();
        float GetPH();
        float GetReactivity();
        float GetSpecificInternalSurfaceArea();
        float GetSurfaceEnergy();
        float GetSurfaceTension();
    }
}
