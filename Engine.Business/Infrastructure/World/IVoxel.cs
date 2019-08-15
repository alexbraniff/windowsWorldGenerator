using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Infrastructure.World
{
    public interface IVoxel : IWorldEntity
    {
        float Noise { get; set; }
        IMaterial Material { get; set; }
        PhongMaterial PhysicalMaterial { get; set; }
        
        event EventHandler<EventArgs> Initialized;
    }
}
