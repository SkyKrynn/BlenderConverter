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
        public float[,] Normals { get; private set; }
        public int[,] Faces { get; private set; }

        public ModelData(ModelInfo info)
        {
            Positions = new float[info.Positions,3];
            Texels = new float[info.Texels,2];
            Normals = new float[info.Normals,3];
            Faces = new int[info.Faces,9];
        }
    }
}
