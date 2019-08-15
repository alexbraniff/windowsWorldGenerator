//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Media.Media3D;
//using Engine.Core.Infrastructure.World;
//using HelixToolkit.Wpf.SharpDX;
//using SharpDX;

//namespace Engine.Core.World
//{
//	public class Block : Entity, IBlock
//    {
//        protected Vector3 Dimensions;
//        protected Vector3 Coordinates;
//        protected Dictionary<Vector3, IVoxel> Voxels = new Dictionary<Vector3, IVoxel>();
//        protected IChunk Chunk;
//        public Dictionary<Vector3, MeshGeometryModel3D> VoxelGeometry = new Dictionary<Vector3, MeshGeometryModel3D>();

//        /// <summary>
//        /// Called at the start of the game.
//        /// </summary>
//        protected override void OnGameplayStart()
//        {
//        }

//		/// <summary>
//		/// Called once every frame when the game is running.
//		/// </summary>
//		/// <param name="frameTime">The time difference between this and the previous frame.</param>
//		protected override void OnUpdate(float frameTime)
//		{
			
//		}

//        public Vector3 GetDimensions()
//        {
//            return Dimensions;
//        }

//        public Vector3 GetCoordinates()
//        {
//            return Coordinates;
//        }

//        public IBlock Initialize(IChunk chunk, Vector3 dimensions, Vector3 coordinates)
//        {
//            Chunk = chunk;
//            Dimensions = dimensions;
//            Coordinates = coordinates;

//            Generate();

//            return this;
//        }

//        public Dictionary<Vector3, IVoxel> GetVoxelDictionary()
//        {
//            return Voxels;
//        }

//        public List<IVoxel> GetVoxelList()
//        {
//            return Voxels.Values.ToList();
//        }

//        public IChunk GetChunk()
//        {
//            return Chunk;
//        }

//        public IWorld GetWorld()
//        {
//            return Chunk.GetWorld();
//        }

//        public IProcedural Generate()
//        {
//            for (int x = 0; x < Chunk.GetWorld().GetBlockVoxelCountDefault().X; x++)
//            {
//                for (int y = 0; y < Chunk.GetWorld().GetBlockVoxelCountDefault().Y; y++)
//                {
//                    for (int z = 0; z < Chunk.GetWorld().GetBlockVoxelCountDefault().Z; z++)
//                    {
//                        Vector3 coords = new Vector3(Vector3.Zero.X + x, Vector3.Zero.Y + y, Vector3.Zero.Z + z);
//                        IVoxel voxel = new Voxel().Initialize(this, Chunk.GetWorld().GetVoxelSizeDefault(), coords);
//                        Voxels.Add(coords, voxel);
//                        VoxelGeometry.Add(coords, voxel.GetGeometry());
//                        //System.Diagnostics.Debug.WriteLine($"V:{x},{y},{z},{voxel.GetGeometry().CullMode}");
//                    }
//                }
//            }

//            return this;
//        }

//        public IEnumerable<KeyValuePair<Vector3, MeshGeometryModel3D>> GetGeometry()
//        {
//            return VoxelGeometry;
//        }
//    }
//}