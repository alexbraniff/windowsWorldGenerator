namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IMechanical
    {
        float GetBrittleness();
        float GetBulkModulus();
        float GetCoefficientOfRestitution();
        float GetCompressiveStrength();
        float GetCreep();
        float GetDuctility();
        float GetDurability();
        float GetElasticity();
        float GetFatigueLimit();
        float GetFlexibility();
        float GetFlexuralModulus();
        float GetFlexuralStrength();
        float GetFractureToughness();
        float GetHardness();
        float GetPlasticity();
        float GetPoissonsRatio();
        float GetResilience();
        float GetShearModulus();
        float GetShearStrength();
        float GetSlip();
        float GetSpecificModulus();
        float GetSpecificStrength();
        float GetSpecificWeight();
        float GetStiffness();
        float GetSurfaceRoughness();
        float GetTensileStrength();
        float GetToughness();
        float GetViscosity();
        float GetYieldStrength();
        float GetYoungsModulus();
    }
}
