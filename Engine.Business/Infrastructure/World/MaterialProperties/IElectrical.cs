namespace Engine.Core.Infrastructure.World.MaterialProperties
{
    public interface IElectrical
    {
        float GetCapacitance();
        float GetDielectricConstant();
        float GetDielectricStrength();
        float GetResistivity();
        float GetConductivity();
        float GetPermittivity();
        float GetPiezoelectricConstants();
        float GetSeebeckCoefficient();
    }
}
