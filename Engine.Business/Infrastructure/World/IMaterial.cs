using Engine.Core.Infrastructure.World.MaterialProperties;

namespace Engine.Core.Infrastructure.World
{
    public interface IMaterial
    {
        IAcoustic GetAcousticProperties();
        IAtomic GetAtomicProperties();
        IChemical GetChemicalProperties();
        IElectrical GetElectricalProperties();
        IEnvironmental GetEnvironmentalProperties();
        IMagnetic GetMagneticProperties();
        IManufacturing GetManufacturingProperties();
        IMechanical GetMechanicalProperties();
        IOptical GetOpticalProperties();
        IRadiological GetRadiologicalProperties();
        IThermoDynamics GetThermoDynamicsProperties();
    }
}
