using LibNoise;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Infrastructure.World
{
    public interface IWorld : IProcedural
    {
        List<IVoxel> Voxels { get; }
        List<IWorldEntity> UnloadedEntities { get; }
        List<IWorldEntity> LoadedEntities { get; }
        IModule3D NoiseModule { get; }
        Vector3 VoxelSize { get; }

        int Seed { get; }
        NoiseQuality NoiseQuality { get; }

        IWorld GameplayStart();
        IWorld Tick(float delta);
    }
}
