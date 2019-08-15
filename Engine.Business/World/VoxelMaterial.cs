using Engine.Core.Infrastructure.World;
using Engine.Core.Infrastructure.World.MaterialProperties;

namespace Engine.Core.World
{
    public class VoxelMaterial : IMaterial
    {
        protected IAcoustic Acoustics { get; set; }
        protected IAtomic Atomic { get; set; }
        protected IChemical Chemical { get; set; }
        protected IElectrical Electrical { get; set; }
        protected IEnvironmental Environmental { get; set; }
        protected IMagnetic Magnetic { get; set; }
        protected IManufacturing Manufacturing { get; set; }
        protected IMechanical Mechanical { get; set; }
        protected IOptical Optical { get; set; }
        protected IRadiological Radiological { get; set; }
        protected IThermoDynamics ThermoDynamics { get; set; }

        public IAcoustic GetAcousticProperties()
        {
            return Acoustics;
        }

        public IAtomic GetAtomicProperties()
        {
            return Atomic;
        }

        public IChemical GetChemicalProperties()
        {
            return Chemical;
        }

        public IElectrical GetElectricalProperties()
        {
            return Electrical;
        }

        public IEnvironmental GetEnvironmentalProperties()
        {
            return Environmental;
        }

        public IMagnetic GetMagneticProperties()
        {
            return Magnetic;
        }

        public IManufacturing GetManufacturingProperties()
        {
            return Manufacturing;
        }

        public IMechanical GetMechanicalProperties()
        {
            return Mechanical;
        }

        public IOptical GetOpticalProperties()
        {
            return Optical;
        }

        public IRadiological GetRadiologicalProperties()
        {
            return Radiological;
        }

        public IThermoDynamics GetThermoDynamicsProperties()
        {
            return ThermoDynamics;
        }
    }
}
