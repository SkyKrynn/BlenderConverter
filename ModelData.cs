using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class ModelData
    {
        public float[,] Positions { get; private set; }
        public float[,] Texels { get; private set; }
        public float[,] Colors { get; private set; }
        public float[,] Normals { get; private set; }
        public int[,] Faces { get; private set; }

        public ModelData(ModelInfo info)
        {
            Positions = new float[info.NumPositions, 3];
            Texels = new float[info.NumTexels, 2];
            Colors = new float[info.NumColors, 4];
            Normals = new float[info.NumNormals, 3];
            Faces = new int[info.NumFaces, 9];
        }
    }
}
