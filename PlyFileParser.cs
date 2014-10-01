using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blender_Converter
{
    class PlyFileParser : IModelFileParser
    {
        private string mFilename;
        private ModelInfo mInfo;
        private ModelData mData;

        public PlyFileParser(String filename)
        {
            mFilename = filename;
            getInfo();
            getData();
        }

        public ModelInfo getInfo()
        {
            if (mInfo != null)
                return mInfo;

            using (StreamReader reader = new StreamReader(mFilename))
            {
                String buffer;
                mInfo = new ModelInfo(Path.GetFileName(mFilename));
                Boolean inHeader = true;
                Boolean readingVertices = false;
                Boolean readingFaces = false;
                int numVerticesRead = 0;
                int numFacesRead = 0;
                    

                while ((buffer = reader.ReadLine()) != null)
                {
                    String[] tokens = buffer.Split(' ');

                    if(inHeader)
                    {
                        switch(tokens[0])
                        {
                            case "end_header":
                                inHeader = false;
                                readingVertices = true;
                                break;
                            case "element":
                                if (tokens[1].Equals("vertex"))
                                {
                                    mInfo.NumPositions = int.Parse(tokens[2]);
                                    mInfo.NumNormals = mInfo.NumPositions;
                                    mInfo.NumColors = mInfo.NumPositions;
                                }

                                if (tokens[1].Equals("face"))
                                    mInfo.NumFaces = int.Parse(tokens[2]);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if(readingVertices)
                        {
                            numVerticesRead++;
                            if(numVerticesRead >= mInfo.NumPositions)
                            {
                                readingVertices = false;
                                readingFaces = true;
                                continue;
                            }
                        }

                        if(readingFaces)
                        {
                            numFacesRead++;
                            if (int.Parse(tokens[0]) == 4)
                                mInfo.NumFaces++;
                        }
                    }
                }
                mInfo.NumVertices = mInfo.NumFaces * 3;
                mInfo.NumTexels = 0;
                return mInfo;
            }
        }

        public ModelData getData()
        {
            if (mData != null)
                return mData;

            using (StreamReader reader = new StreamReader(mFilename))
            {
                String buffer;
                mData = new ModelData(getInfo());
                Boolean inHeader = true;
                Boolean readingVertices = false;
                Boolean readingFaces = false;
                int numVerticesRead = 0;
                int numFacesRead = 0;


                while ((buffer = reader.ReadLine()) != null)
                {
                    String[] tokens = buffer.Split(' ');

                    if (inHeader)
                    {
                        switch (tokens[0])
                        {
                            case "end_header":
                                inHeader = false;
                                readingVertices = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (readingVertices)
                        {
                            mData.Positions[numVerticesRead, 0] = float.Parse(tokens[0]);
                            mData.Positions[numVerticesRead, 1] = float.Parse(tokens[1]);
                            mData.Positions[numVerticesRead, 2] = float.Parse(tokens[2]);

                            mData.Normals[numVerticesRead, 0] = float.Parse(tokens[3]);
                            mData.Normals[numVerticesRead, 1] = float.Parse(tokens[4]);
                            mData.Normals[numVerticesRead, 2] = float.Parse(tokens[5]);

                            mData.Colors[numVerticesRead, 0] = float.Parse(tokens[6]);
                            mData.Colors[numVerticesRead, 1] = float.Parse(tokens[7]);
                            mData.Colors[numVerticesRead, 2] = float.Parse(tokens[8]);
                            mData.Colors[numVerticesRead, 3] = 1.0f;

                            numVerticesRead++;
                            if (numVerticesRead >= mInfo.NumPositions)
                            {
                                readingVertices = false;
                                readingFaces = true;
                                continue;
                            }
                        }

                        if (readingFaces)
                        {
                            mData.Faces[numFacesRead, 0] = int.Parse(tokens[1]) + 1;
                            mData.Faces[numFacesRead, 1] = int.Parse(tokens[1]) + 1;
                            mData.Faces[numFacesRead, 2] = int.Parse(tokens[1]) + 1;

                            mData.Faces[numFacesRead, 3] = int.Parse(tokens[2]) + 1;
                            mData.Faces[numFacesRead, 4] = int.Parse(tokens[2]) + 1;
                            mData.Faces[numFacesRead, 5] = int.Parse(tokens[2]) + 1;

                            mData.Faces[numFacesRead, 6] = int.Parse(tokens[3]) + 1;
                            mData.Faces[numFacesRead, 7] = int.Parse(tokens[3]) + 1;
                            mData.Faces[numFacesRead, 8] = int.Parse(tokens[3]) + 1;

                            numFacesRead++;

                            if (int.Parse(tokens[0]) == 4)
                            {
                                mData.Faces[numFacesRead, 3] = int.Parse(tokens[2]) + 1;
                                mData.Faces[numFacesRead, 4] = int.Parse(tokens[2]) + 1;
                                mData.Faces[numFacesRead, 5] = int.Parse(tokens[2]) + 1;

                                mData.Faces[numFacesRead, 6] = int.Parse(tokens[3]) + 1;
                                mData.Faces[numFacesRead, 7] = int.Parse(tokens[3]) + 1;
                                mData.Faces[numFacesRead, 8] = int.Parse(tokens[3]) + 1;

                                mData.Faces[numFacesRead, 0] = int.Parse(tokens[4]) + 1;
                                mData.Faces[numFacesRead, 1] = int.Parse(tokens[4]) + 1;
                                mData.Faces[numFacesRead, 2] = int.Parse(tokens[4]) + 1;

                                numFacesRead++;
                            }
                        }
                    }
                }

                //int idxPos = 0;
                //int idxTex = 0;
                //int idxNor = 0;
                //int idxFac = 0;
                //while ((buffer = reader.ReadLine()) != null)
                //{
                //    String[] tokens = buffer.Split(' ');
                //    switch (tokens[0])
                //    {
                //        case "v":
                //            mData.Positions[idxPos, 0] = float.Parse(tokens[1]);
                //            mData.Positions[idxPos, 1] = float.Parse(tokens[2]);
                //            mData.Positions[idxPos, 2] = float.Parse(tokens[3]);
                //            idxPos++;
                //            break;
                //        case "vt":
                //            mData.Texels[idxTex, 0] = float.Parse(tokens[1]);
                //            mData.Texels[idxTex, 1] = float.Parse(tokens[2]);
                //            idxTex++;
                //            break;
                //        case "vn":
                //            mData.Normals[idxNor, 0] = float.Parse(tokens[1]);
                //            mData.Normals[idxNor, 1] = float.Parse(tokens[2]);
                //            mData.Normals[idxNor, 2] = float.Parse(tokens[3]);
                //            idxNor++;
                //            break;
                //        case "f":
                //            String[] index = tokens[1].Split('/');
                //            mData.Faces[idxFac, 0] = int.Parse(index[0]);
                //            mData.Faces[idxFac, 1] = int.Parse(index[1]);
                //            mData.Faces[idxFac, 2] = int.Parse(index[2]);
                //            index = tokens[2].Split('/');
                //            mData.Faces[idxFac, 3] = int.Parse(index[0]);
                //            mData.Faces[idxFac, 4] = int.Parse(index[1]);
                //            mData.Faces[idxFac, 5] = int.Parse(index[2]);
                //            index = tokens[3].Split('/');
                //            mData.Faces[idxFac, 6] = int.Parse(index[0]);
                //            mData.Faces[idxFac, 7] = int.Parse(index[1]);
                //            mData.Faces[idxFac, 8] = int.Parse(index[2]);
                //            idxFac++;
                //            break;
                //        default:
                //            break;
                //    }
                //}
                return mData;
            }
        }
    }
}
