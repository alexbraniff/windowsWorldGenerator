using Engine.Core.World;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Engine.Core.Infrastructure.World
{
    public interface IChunk : IContainer, IProcedural
    {
        IChunk Initialize(IWorld world, Vector3 dimensions, Vector3 coordinates);
        Dictionary<Vector3, IBlock> GetBlockDictionary();
        List<IBlock> GetBlockList();
        IWorld GetWorld();
        IEnumerable<KeyValuePair<Vector3, IEnumerable<KeyValuePair<Vector3, Entity>>>> GetGeometry();
    }
}
