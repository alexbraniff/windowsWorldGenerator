//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Media.Media3D;
//using Engine.Core.Infrastructure.World;
//using HelixToolkit.Wpf;
//using HelixToolkit.Wpf.SharpDX;
//using SharpDX;

//namespace Engine.Core.World
//{
//	public class Chunk : IChunk
//    {
//        protected Vector3 Dimensions = new Vector3(0, 0, 0);
//        protected Vector3 Coordinates;
//        protected Dictionary<Vector3, IBlock> Blocks = new Dictionary<Vector3, IBlock>();
//        protected IWorld World;
//        protected IEnumerable<KeyValuePair<Vector3, IEnumerable<KeyValuePair<Vector3, Entity>>>> BlockGeometry = new Dictionary<Vector3, IEnumerable<KeyValuePair<Vector3, Entity>>>();

//        public Vector3 GetDimensions()
//        {
//            return Dimensions;
//        }

//        public Vector3 GetCoordinates()
//        {
//            return Coordinates;
//        }

//        public Dictionary<Vector3, IBlock> GetBlockDictionary()
//        {
//            return Blocks;
//        }

//        public List<IBlock> GetBlockList()
//        {
//            return Blocks.Values.ToList();
//        }

//        public IChunk Initialize(IWorld world, Vector3 dimensions, Vector3 coordinates)
//        {
//            World = world;
//            Dimensions = dimensions;
//            Coordinates = coordinates;

//            Generate();

//            return this;
//        }

//        public IWorld GetWorld()
//        {
//            return World;
//        }

//        public IProcedural Generate()
//        {
//            for (int x = 0; x < World.GetChunkBlockCountDefault().X; x++)
//            {
//                for (int y = 0; y < World.GetChunkBlockCountDefault().Y; y++)
//                {
//                    for (int z = 0; z < World.GetChunkBlockCountDefault().Z; z++)
//                    {
//                        //System.Diagnostics.Debug.WriteLine($"B:{x},{y},{z}");
//                        Vector3 coords = new Vector3(x, y, z);
//                        IBlock block = new Block().Initialize(this, World.GetBlockVoxelCountDefault(), coords);
//                        Blocks.Add(coords, block);

//                    }
//                }
//            }

//            return this;
//        }

//        public IEnumerable<KeyValuePair<Vector3, IEnumerable<KeyValuePair<Vector3, Entity>>>> GetGeometry()
//        {
//            return BlockGeometry;
//        }
//    }
//}