using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class JavaCodeGenerator : ICodeGenerator
    {
        private ModelInfo mInfo;
        private ModelData mData;

        public JavaCodeGenerator(ModelInfo info, ModelData data)
        {
            mInfo = info;
            mData = data;
        }

        public void CreateCode(String dir, String baseclassname)
        {
            String mOutputFile = Path.Combine(dir, baseclassname + ".java");
            using (StreamWriter writer = new StreamWriter(mOutputFile))
            {
                writer.WriteLine();
                writer.WriteLine("//");
                writer.WriteLine("// Auto-generated file");
                writer.WriteLine("//");
                writer.WriteLine();
                writer.WriteLine("// Original file: " + mInfo.OriginalFileName);
                writer.WriteLine("// Positions: " + mInfo.NumPositions);
                writer.WriteLine("// Texels: " + mInfo.NumTexels);
                writer.WriteLine("// Normals: " + mInfo.NumNormals);
                writer.WriteLine("// Faces: " + mInfo.NumFaces);
                writer.WriteLine("// Vertices: " + mInfo.NumVertices);
                writer.WriteLine();
                writer.WriteLine("public final class " + baseclassname + " {");
                writer.WriteLine();

                WriteDataBuffers(writer);

                writer.WriteLine();
                writer.WriteLine("}");
            }
        }

        private void WriteDataBuffers(StreamWriter writer)
        {
            WritePositions(writer);
            WriteNormals(writer);
            WriteColors(writer);
            WriteTexels(writer);
        }

        private void WritePositions(StreamWriter writer)
        {
            writer.WriteLine("\tpublic static final float[] COORDS = new float[] {");

            int v1;
            int v2;
            int v3; 

            for (int idx = 0; idx < mInfo.NumFaces; idx++)
            {
                v1 = mData.Faces[idx, 0] - 1;
                v2 = mData.Faces[idx, 3] - 1;
                v3 = mData.Faces[idx, 6] - 1 ;

                writer.WriteLine("\t\t\t " + mData.Positions[v1, 0].ToString("0.000000") + "f, " + mData.Positions[v1, 1].ToString("0.000000") + "f, " + mData.Positions[v1, 2].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Positions[v2, 0].ToString("0.000000") + "f, " + mData.Positions[v2, 1].ToString("0.000000") + "f, " + mData.Positions[v2, 2].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Positions[v3, 0].ToString("0.000000") + "f, " + mData.Positions[v3, 1].ToString("0.000000") + "f, " + mData.Positions[v3, 2].ToString("0.000000") + "f,");
            }
            
            writer.WriteLine("\t};");
            writer.WriteLine();
        }

        private void WriteColors(StreamWriter writer)
        {
            writer.WriteLine("\tpublic static final float[] COLORS = new float[] {");

            int v1;
            int v2;
            int v3;

            for (int idx = 0; idx < mInfo.NumFaces; idx++)
            {
                try
                {
                    v1 = mData.Faces[idx, 0] - 1;
                    v2 = mData.Faces[idx, 3] - 1;
                    v3 = mData.Faces[idx, 6] - 1;
                    if (mInfo.NumColors > 0)
                    {
                        writer.WriteLine("\t\t\t " + mData.Colors[v1, 0].ToString("0.000000") + "f, " + mData.Colors[v1, 1].ToString("0.000000") + "f, " + mData.Colors[v1, 2].ToString("0.000000") + "f, " + mData.Colors[v1, 3].ToString("0.000000") + "f,");
                        writer.WriteLine("\t\t\t " + mData.Colors[v2, 0].ToString("0.000000") + "f, " + mData.Colors[v2, 1].ToString("0.000000") + "f, " + mData.Colors[v2, 2].ToString("0.000000") + "f, " + mData.Colors[v2, 3].ToString("0.000000") + "f,");
                        writer.WriteLine("\t\t\t " + mData.Colors[v3, 0].ToString("0.000000") + "f, " + mData.Colors[v3, 1].ToString("0.000000") + "f, " + mData.Colors[v3, 2].ToString("0.000000") + "f, " + mData.Colors[v3, 3].ToString("0.000000") + "f,");
                    }
                    else
                    {
                        writer.WriteLine("\t\t\t 1.000000f, 0.652300f, 0.000000f, 1.000000f,");
                        writer.WriteLine("\t\t\t 1.000000f, 0.652300f, 0.000000f, 1.000000f,");
                        writer.WriteLine("\t\t\t 1.000000f, 0.652300f, 0.000000f, 1.000000f,");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            writer.WriteLine("\t};");
            writer.WriteLine();
        }

        private void WriteTexels(StreamWriter writer)
        {
            if (mInfo.NumTexels == 0)
                return;

            writer.WriteLine("\tpublic static final float[] TEXELS = new float[] {");

            for (int idx = 0; idx < mInfo.NumFaces; idx++)
            {
                int v1 = mData.Faces[idx, 1] - 1;
                int v2 = mData.Faces[idx, 4] - 1;
                int v3 = mData.Faces[idx, 7] - 1;

                writer.WriteLine("\t\t\t " + mData.Texels[v1, 0].ToString("0.000000") + "f, " + mData.Texels[v1, 1].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Texels[v2, 0].ToString("0.000000") + "f, " + mData.Texels[v2, 1].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Texels[v3, 0].ToString("0.000000") + "f, " + mData.Texels[v3, 1].ToString("0.000000") + "f,");
            }

            writer.WriteLine("\t};");
            writer.WriteLine();
        }

        private void WriteNormals(StreamWriter writer)
        {
            writer.WriteLine("\tpublic static final float[] NORMALS = new float[] {");

            for (int idx = 0; idx < mInfo.NumFaces; idx++)
            {
                int v1 = mData.Faces[idx, 2] - 1;
                int v2 = mData.Faces[idx, 5] - 1;
                int v3 = mData.Faces[idx, 8] - 1;

                writer.WriteLine("\t\t\t " + mData.Normals[v1, 0].ToString("0.000000") + "f, " + mData.Normals[v1, 1].ToString("0.000000") + "f, " + mData.Normals[v1, 2].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Normals[v2, 0].ToString("0.000000") + "f, " + mData.Normals[v2, 1].ToString("0.000000") + "f, " + mData.Normals[v2, 2].ToString("0.000000") + "f,");
                writer.WriteLine("\t\t\t " + mData.Normals[v3, 0].ToString("0.000000") + "f, " + mData.Normals[v3, 1].ToString("0.000000") + "f, " + mData.Normals[v3, 2].ToString("0.000000") + "f,");
            }

            writer.WriteLine("\t};");
            writer.WriteLine();
        }

    }
}
