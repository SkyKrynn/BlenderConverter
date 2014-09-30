using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class ModelInfo
    {
        public int Vertices { get { return Faces * 3; } }
        public int Positions { get; set; }
        public int Texels { get; set; }
        public int Normals { get; set; }
        public int Faces { get; set; }
        public string OriginalFileName { get; set; }
    }
}
