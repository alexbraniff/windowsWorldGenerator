using HelixToolkit.Wpf.SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Infrastructure.World;
using Engine.Core.Infrastructure.World.MaterialProperties;
using Engine.Core.World.MaterialProperties;
using SharpDX;
using Engine.Core.Extensions;

namespace Engine.Core.World
{
    public class Material : Infrastructure.World.IMaterial
    {
        protected HelixToolkit.Wpf.SharpDX.IMaterial SharpMaterial;

        protected IAcoustic AcousticProperties;

        protected IAtomic AtomicProperties;

        protected IChemical ChemicalProperties;

        protected IElectrical ElectricalProperties;

        protected IEnvironmental EnvironmentalProperties;

        protected IMagnetic MagneticProperties;

        protected IManufacturing ManufacturingProperties;

        protected IMechanical MechanicalProperties;

        protected IOptical OpticalProperties;

        protected IRadiological RadiologicalProperties;

        protected IThermoDynamics ThermoDynamicsProperties;

        protected float Noise;

        public Color4 Color { get; set; }

        public PhongMaterial PhysicalMaterial { get; set; }

        public Material(float noise)
        {
            Noise = noise;
            AcousticProperties = new Acoustic();
            AtomicProperties = new Atomic();
            ChemicalProperties = new Chemical();
            ElectricalProperties = new Electrical();
            EnvironmentalProperties = new Environmental();
            MagneticProperties = new Magnetic();
            ManufacturingProperties = new Manufacturing();
            MechanicalProperties = new Mechanical();
            OpticalProperties = new Optical();
            RadiologicalProperties = new Radiological();
            ThermoDynamicsProperties = new ThermoDynamics();

            float input_start = -1;
            float input_end = 1;
            float output_start = 0;
            float output_end = 256 * 256 * 256;

            double output;

            double slope = 1.0 * (output_end - output_start) / (input_end - input_start);

            output = output_start + slope * (Noise - input_start);

            float Positive = Noise.Spread(-1, 1, 0, 1);

            float r = Voxel.GetRed(Positive);
            float g = Voxel.GetGreen(Positive);
            float b = Voxel.GetBlue(Positive);
            float a = Voxel.GetAlpha(Noise);

            PhysicalMaterial = new PhongMaterial
            {
                DiffuseColor = new Color4(r, g, b, a)
            };
        }

        public IAcoustic GetAcousticProperties()
        {
            return AcousticProperties;
        }

        public IAtomic GetAtomicProperties()
        {
            return AtomicProperties;
        }

        public IChemical GetChemicalProperties()
        {
            return ChemicalProperties;
        }

        public IElectrical GetElectricalProperties()
        {
            return ElectricalProperties;
        }

        public IEnvironmental GetEnvironmentalProperties()
        {
            return EnvironmentalProperties;
        }

        public IMagnetic GetMagneticProperties()
        {
            return MagneticProperties;
        }

        public IManufacturing GetManufacturingProperties()
        {
            return ManufacturingProperties;
        }

        public IMechanical GetMechanicalProperties()
        {
            return MechanicalProperties;
        }

        public IOptical GetOpticalProperties()
        {
            return OpticalProperties;
        }

        public IRadiological GetRadiologicalProperties()
        {
            return RadiologicalProperties;
        }

        public IThermoDynamics GetThermoDynamicsProperties()
        {
            return ThermoDynamicsProperties;
        }
    }
}
