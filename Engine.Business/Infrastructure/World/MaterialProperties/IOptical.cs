namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IOptical
    {
        float GetAbsorbance();
        float GetBirefringence();
        float GetColor();
        float GetLuminosity();
        float GetPhotosensitivity();
        float GetReflectivity();
        float GetRefractiveIndex();
        float GetScattering();
        float GetTransmittance();
    }
}
