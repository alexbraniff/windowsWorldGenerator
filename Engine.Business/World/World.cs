using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Engine.Core.Infrastructure.World;
using HelixToolkit.Wpf.SharpDX;
using LibNoise;
using LibNoise.Primitive;
using SharpDX;

namespace Engine.Core.World
{
    public class World : IWorld
    {
        public List<IWorldEntity> UnloadedEntities { get; set; } = new List<IWorldEntity>();

        public List<IWorldEntity> LoadedEntities { get; set; } = new List<IWorldEntity>();

        public List<IVoxel> Voxels { get; set; } = new List<IVoxel>();

        public Vector3 Bounds { get; set; }

        public IModule3D NoiseModule { get; set; }

        public IModule2D NoiseModule2D { get; set; }

        public Vector3 VoxelSize { get; set; }

        public int Seed { get; set; }

        public NoiseQuality NoiseQuality { get; set; }

        public event EventHandler<EventArgs> Generated;
        public event EventHandler<EventArgs> Initialized;

        public IWorld GameplayStart()
        {
            Voxels.ToList().ForEach(e => e.OnGameplayStart());
            LoadedEntities.ToList().ForEach(e => e.OnGameplayStart());
            UnloadedEntities.ToList().ForEach(e => e.OnGameplayStart());

            return this;
        }

        public IWorld Tick(float delta)
        {
            Voxels.ToList().ForEach(e => e.OnTick(delta));
            LoadedEntities.ToList().ForEach(e => e.OnTick(delta));
            UnloadedEntities.ToList().ForEach(e => e.OnTick(delta));

            return this;
        }

        public World()
        {
        }

        public IProcedural Generate()
        {
            int i = 0;
            for (int x = 0; x < Bounds.X; x++)
            {
                int y = 0;
                int z = 0;
                //System.Diagnostics.Debug.WriteLine($"V:{x},{y},{z} | {VoxelSize}");
                for (y = 0; y < Bounds.Y; y++)
                {
                    for (z = 0; z < Bounds.Z; z++)
                    {
                        Vector3 coords = new Vector3(x, y, z) * VoxelSize;
                        var n = NoiseModule2D.GetValue(x, z);
                        Dictionary<ECubeFace, float> noisyNeighbors = new Dictionary<ECubeFace, float>();
                        noisyNeighbors.Add(ECubeFace.Top, NoiseModule.GetValue(x, y + 1, z));
                        noisyNeighbors.Add(ECubeFace.Bottom, NoiseModule.GetValue(x, y - 1, z));
                        noisyNeighbors.Add(ECubeFace.Left, NoiseModule.GetValue(x - 1, y, z));
                        noisyNeighbors.Add(ECubeFace.Right, NoiseModule.GetValue(x + 1, y, z));
                        noisyNeighbors.Add(ECubeFace.Front, NoiseModule.GetValue(x, y, z - 1));
                        noisyNeighbors.Add(ECubeFace.Back, NoiseModule.GetValue(x, y, z + 1));
                        IVoxel voxel = new Voxel
                        {
                            Id = Guid.NewGuid(),
                            Bounds = VoxelSize,
                            Coordinates = coords,
                            Noise = n,
                            NeighborNoiseValues = noisyNeighbors,
                            Material = new Material(n)
                        };
                        voxel.Generated += OnVoxelInitialized;
                        Debug.WriteLine($"Voxel: {i}");
                        voxel.Generate();
                    }
                }
            }

            if (Voxels.Count == Bounds.X * Bounds.Y * Bounds.Z)
            {
                Generated.Invoke(this, new EventArgs());
            }

            return this;
        }

        private void OnVoxelInitialized(object sender, EventArgs args)
        {
            Voxels.Add((Voxel)sender);
            if (Voxels.Count % 10 == 0 || Voxels.Count == Bounds.X * Bounds.Y * Bounds.Z)
                Debug.WriteLine($"{Voxels.Count}\t== {Bounds.X * Bounds.Y * Bounds.Z} ? {Voxels.Count == Bounds.X * Bounds.Y * Bounds.Z}");
        }
    }
}