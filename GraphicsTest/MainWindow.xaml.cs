using Engine.Core.Infrastructure.World;
using Engine.Core.World;
using Engine.MVVM;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Model;
using LibNoise;
using LibNoise.Primitive;
using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using Color = System.Windows.Media.Color;
using Colors = System.Windows.Media.Colors;

namespace GraphicsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.Xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EffectsManager manager;
        private Viewport3DX Viewport;
        private EnvironmentMap3D EnvironmentMap;
        private MainViewModel viewmodel = new MainViewModel();
        private World World;
        private GroupModel3D WorldMeshes;
        private readonly BackgroundWorker Worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            manager = new DefaultEffectsManager();
            DataContext = viewmodel;

            //InstantiateWorkerThread();

            Worker.DoWork += StartWorker;
            Worker.RunWorkerCompleted += StartWorker_Completed;

            Worker.RunWorkerAsync();
        }

        private void StartWorker(object sender, DoWorkEventArgs e)
        {
            Start();
        }

        private void StartWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            while (World == null || WorldMeshes == null || WorldMeshes.Children.Count < World.Bounds.X * World.Bounds.Y * World.Bounds.Z) { ; }
            
            AddToViewport(Viewport, WorldMeshes);
            AddToGrid(mainGrid, Viewport);
        }

        private void Start()
        {
            Viewport = InitializeViewport();
            World = (World)InitializeWorld();
        }

        private IWorld InitializeWorld()
        {
            //Initialize(0, NoiseQuality.Best, new Vector3(16, 16, 16), new Vector3(1,1,1));
            var seed = 0;
            var noiseQuality = NoiseQuality.Best;
            var world = new World
            {
                Seed = seed,
                NoiseQuality = noiseQuality,
                Bounds = new Vector3(16, 16, 16),
                VoxelSize = new Vector3(1, 1, 1),
                NoiseModule = new SimplexPerlin
                {
                    Seed = seed,
                    Quality = noiseQuality
                },
                NoiseModule2D = new SimplexPerlin
                {
                    Seed = seed,
                    Quality = noiseQuality
                }
            };
            world.Generated += OnWorldGenerated;
            world.Generate();
            return world.GameplayStart();
        }

        private void OnViewportGenerated(object state)
        {
        }

        private void OnWorldGenerated(object sender, EventArgs args)
        {
            var world = (World)sender;

            WorldMeshes = new GroupModel3D();

            world.Voxels.ToList().ForEach(vox =>
            {
                var voxel = (Voxel)vox;

                CubeFace face;

                MeshBuilder b = new MeshBuilder();

                voxel.GetVisibleCubeFaces().ForEach(f =>
                {
                    if (voxel.Faces.TryGetValue(f, out face))
                    {
                        b.AddCubeFace(face.CubeCenter, face.Normal, face.Up, face.Distance, face.Width, face.Height);
                    }
                });

                var mm = b.ToMesh();

                var simHelper = new MeshSimplification(mm);

                int size = mm.Indices.Count / 3 / 2;

                var m = simHelper.Simplify(size, 7, true, true);

                var mesh = new MeshGeometryModel3D
                {
                    Geometry = mm,
                    CullMode = SharpDX.Direct3D11.CullMode.Back
                };

                var scale = new ScaleTransform3D(1, 1, 1);
                var translate = new TranslateTransform3D(0, 0, 0);
                var group = new Transform3DGroup();

                group.Children.Add(scale);
                group.Children.Add(translate);
                mesh.Transform = group;

                mesh.Material = voxel.PhysicalMaterial;
                if (((Engine.Core.World.Material)voxel.Material).PhysicalMaterial.DiffuseColor.Alpha < 1)
                {
                    mesh.IsTransparent = true;
                }

                WorldMeshes.Children.Add(mesh);

                voxel.Mesh = mesh;
            });

            //Viewport = InitializeViewport();

            //while (Viewport == null) { Debug.WriteLine($"Waiting for Viewport..."); }

        }

        private void AddToViewport(Viewport3DX viewport, Element3D element)
        {
            //Dispatcher.BeginInvoke(new Func<Viewport3DX>(() =>
            //{
                viewport.Items.Add(element);
                //return viewport;
            //}), DispatcherPriority.Normal);
        }

        private void AddToGrid(Grid grid, UIElement element)
        {
            grid.Children.Add(element);
        }

        private Viewport3DX InitializeViewport()
        {
            return Dispatcher.Invoke(() =>
            {
                Viewport3DX viewport = new Viewport3DX();

                //viewport.Initialized += OnViewportGenerated;
                viewport.BackgroundColor = Colors.DarkSlateGray;
                viewport.ShowCoordinateSystem = false;
                viewport.ShowFrameRate = true;
                viewport.EffectsManager = manager;
                viewport.Items.Add(new DirectionalLight3D() { Direction = new System.Windows.Media.Media3D.Vector3D(1, -1, 1) });
                viewport.Items.Add(new AmbientLight3D() { Color = Color.FromArgb(255, 50, 50, 50) });
                Grid.SetColumn(viewport, 0);
                return viewport;
            });
        }

        private EnvironmentMap3D InitializeEnvironment()
        {
            var texture = BaseViewModel.LoadFileToMemory("Cubemap_Grandcanyon.dds");
            return new EnvironmentMap3D() { Texture = texture };
        }
    }
}
