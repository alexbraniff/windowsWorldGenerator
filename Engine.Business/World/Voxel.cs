using Engine.Core.Extensions;
using Engine.Core.Infrastructure.World;
using HelixToolkit.Wpf;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Linq;

namespace Engine.Core.World
{
    public class Voxel : IVoxel
    {
        public Guid Id { get; set; }
        public Vector3 Bounds { get; set; }
        public Vector3 Coordinates { get; set; }
        public Infrastructure.World.IMaterial Material { get; set; }
        public float Noise { get; set; }
        public MeshGeometryModel3D Mesh { get; set; }
        public Dictionary<ECubeFace, CubeFace> Faces { get; set; }
        public Dictionary<ECubeFace, Voxel> Neighbors { get; set; }
        public Dictionary<ECubeFace, float> NeighborNoiseValues { get; set; }

        public PhongMaterial PhysicalMaterial { get; set; }

        public event EventHandler<EventArgs> Generated;
        public event EventHandler<EventArgs> Initialized;

        /// <summary>
        /// Called at the start of the game.
        /// </summary>
        public void OnGameplayStart()
		{
		}

		/// <summary>
		/// Called once every frame when the game is running.
		/// </summary>
		/// <param name="frameTime">The time difference between this and the previous frame.</param>
		public void OnTick(float delta)
        {
        }

        public List<ECubeFace> GetVisibleCubeFaces()
        {
            return Enum.GetValues(typeof(ECubeFace)).OfType<ECubeFace>().ToList().Where(IsFaceVisible).ToList();
        }

        public IProcedural Generate()
        {
            GenerateCubeFaces();

            Generated.Invoke(this, new EventArgs());

            return this;
        }

        public static float GetAlpha(float noise)
        {
            return noise.Spread(-1, 1, -0.25f, 1.75f).Clamp(0, 1) > 0.25 ? 0 : 1;
        }

        public float GetAlpha()
        {
            return GetAlpha(Noise);
        }

        public static float GetRed(float noise)
        {
            return noise * 0.5f;
        }

        public float GetRed()
        {
            return GetRed(Noise);
        }

        public static float GetGreen(float noise)
        {
            return noise * 1;
        }

        public float GetGreen()
        {
            return GetGreen(Noise);
        }

        public static float GetBlue(float noise)
        {
            return noise * 0.75f;
        }

        public float GetBlue()
        {
            return GetBlue(Noise);
        }

        public static Color4 GetColor(float noise)
        {
            return new Color4(GetRed(noise), GetGreen(noise), GetBlue(noise), GetAlpha(noise));
        }

        public Color4 GetColor()
        {
            return new Color4(GetRed(Noise), GetGreen(Noise), GetBlue(Noise), GetAlpha(Noise));
        }

        private void GenerateCubeFaces()
        {
            Faces = new Dictionary<ECubeFace, CubeFace>();
            for (int i = 0; i < 6; i ++)
            {
                ECubeFace face = (ECubeFace)i;

                Vector3 normal = new Vector3(0, 0, 0);
                Vector3 up = new Vector3(0, 0, 1);
                double distance = Bounds.X;

                switch (face)
                {
                    case ECubeFace.Front:
                        normal = new Vector3(0, 0, 1);
                        up = new Vector3(0, 1, 0);
                        distance = Bounds.Z;
                        break;
                    case ECubeFace.Back:
                        normal = new Vector3(0, 0, -1);
                        up = new Vector3(0, 1, 0);
                        distance = Bounds.Z;
                        break;
                    case ECubeFace.Left:
                        normal = new Vector3(-1, 0, 0);
                        up = new Vector3(0, 1, 0);
                        distance = Bounds.X;
                        break;
                    case ECubeFace.Right:
                        normal = new Vector3(1, 0, 0);
                        up = new Vector3(0, 1, 0);
                        distance = Bounds.X;
                        break;
                    case ECubeFace.Top:
                        normal = new Vector3(0, 1, 0);
                        distance = Bounds.Y;
                        break;
                    case ECubeFace.Bottom:
                        normal = new Vector3(0, -1, 0);
                        distance = Bounds.Y;
                        break;
                    default:
                        break;
                }

                CubeFace cubeFace = new CubeFace
                {
                    CubeCenter = Coordinates,
                    Normal = normal,
                    Up = up,
                    Distance = distance,
                    Width = Bounds.X,
                    Height = Bounds.Y,
                    Visible = IsFaceVisible(face)
                };

                Faces.Add(face, cubeFace);
            }
        }

        private bool IsFaceVisible(ECubeFace face)
        {
            float noise;
            if (NeighborNoiseValues.TryGetValue(face, out noise))
            {
                string a = GetAlpha(noise).ToString();
                string tabs = a.Length > 8 ? "\t" : a.Length > 4 ? "\t\t" : "\t\t\t";
                //Debug.WriteLine($"{GetAlpha(noise)}{tabs}< 1 ? {(GetAlpha(noise) < 1)}");
                return GetAlpha(noise) < 1;
            }

            return true;
        }

        private IProcedural GenerateMesh()
        {
            //GenerateMaterialProperties();

            //GenerateCubeFaces();

            //while (Material == null) { Debug.WriteLine($"Waiting for material - {Id}"); }

            //Debug.WriteLine($"Got material - {Id}");

            HelixToolkit.Wpf.SharpDX.MeshBuilder b = new HelixToolkit.Wpf.SharpDX.MeshBuilder();

            foreach (var f in Faces)
            {
                var face = f.Value;
                b.AddCubeFace(face.CubeCenter, face.Normal, face.Up, face.Distance, face.Width, face.Height);
            }

            var m = new MeshGeometryModel3D
            {
                Geometry = b.ToMesh(),
                CullMode = SharpDX.Direct3D11.CullMode.Back
            };

            var scale = new ScaleTransform3D(1, 1, 1);
            var translate = new TranslateTransform3D(0, 0, 0);
            var group = new Transform3DGroup();

            group.Children.Add(scale);
            group.Children.Add(translate);
            m.Transform = group;

            m.Material = PhysicalMaterial;
            if (PhysicalMaterial.DiffuseColor.Alpha < 1)
            {
                m.IsTransparent = true;
            }

            Mesh = m;

            return this;
        }
    }
}