using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System.Collections.Generic;

namespace Engine.Core.Infrastructure.World
{
    public interface IBlock : IProcedural, IContainer
    {
        IBlock Initialize(IChunk chunk, Vector3 dimensions, Vector3 coordinates);
        Dictionary<Vector3, IVoxel> GetVoxelDictionary();
        List<IVoxel> GetVoxelList();
        IChunk GetChunk();
        IWorld GetWorld();
        IEnumerable<KeyValuePair<Vector3, MeshGeometryModel3D>> GetGeometry();
    }
}
