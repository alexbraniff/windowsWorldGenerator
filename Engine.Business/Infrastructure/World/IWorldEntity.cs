using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Infrastructure.World
{
    public interface IWorldEntity : IProcedural
    {
        MeshGeometryModel3D Mesh { get; set; }
        Vector3 Coordinates { get; set; }

        Guid Id { get; set; }

        void OnGameplayStart();
        void OnTick(float delta);
    }
}
