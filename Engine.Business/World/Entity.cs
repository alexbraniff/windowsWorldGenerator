using HelixToolkit.Wpf.SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.World
{
    public abstract class Entity
    {
        protected MeshGeometryModel3D Mesh;

        protected abstract void OnGameplayStart();
        protected abstract void OnUpdate(float deltaTime);
    }
}
