using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blender_Converter
{
    public partial class frmMain : Form
    {
        private String mInputFile;
        private IModelFileParser mParser;

        public frmMain()
        {
            InitializeComponent();
            lblObjectFileName.Text = "";
            clear();
        }

        private void clear()
        {
            clearInfo();
            lstData.Items.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dlgOpenObjectFile.ShowDialog() == DialogResult.OK)
            {
                mInputFile = dlgOpenObjectFile.FileName;
                lblObjectFileName.Text = Path.GetFileName(mInputFile);
                txtBaseClassname.Text = Path.GetFileNameWithoutExtension(mInputFile);

                String ext = Path.GetExtension(mInputFile);
                switch(ext)
                {
                    case ".obj":
                        mParser = new ObjFileParser(mInputFile);
                        break;
                    case ".ply":
                        mParser = new PlyFileParser(mInputFile);
                        break;
                    default:
                        throw new NotSupportedException("Unknown file type");
                }

                showInfo(mParser.getInfo());
                showSampleData(mParser.getData());
                txtOuputFolder.Text = Path.GetDirectoryName(mInputFile);
                pnlMain.Enabled = true;
            }
        }

        private void showSampleData(ModelData data)
        {
            lstData.Items.Clear();
            lstData.Items.Add("Model Data");
            lstData.Items.Add("P1: " + data.Positions[0,0] + "x " + data.Positions[0,1] + "y " + data.Positions[0,2] + "z");
            lstData.Items.Add("N1: " + data.Normals[0, 0] + "x " + data.Normals[0, 1] + "y " + data.Normals[0, 2] + "z");
            lstData.Items.Add("F1: " + data.Faces[0, 0] + "p " + data.Faces[0, 1] + "t " + data.Faces[0, 2] + "n");
            if(mParser.getInfo().NumTexels > 0)
                lstData.Items.Add("T1: " + data.Texels[0, 0] + "u " + data.Texels[0, 1] + "v");
            if (mParser.getInfo().NumColors > 0)
                lstData.Items.Add("C1: " + data.Colors[0, 0] + "r " + data.Colors[0, 1] + "g " + data.Colors[0,2] + "b " + data.Colors[0,3] + "a");
        }

        private void clearInfo()
        {
            lblVertices.Text = "";
            lblPositions.Text = "";
            lblTexels.Text = "";
            lblColors.Text = "";
            lblNormals.Text = "";
            lblFaces.Text = "";
        }

        private void showInfo(ModelInfo info)
        {
            lblVertices.Text = info.NumVertices.ToString();
            lblPositions.Text = info.NumPositions.ToString();
            lblTexels.Text = info.NumTexels.ToString();
            lblColors.Text = info.NumColors.ToString();
            lblNormals.Text = info.NumNormals.ToString();
            lblFaces.Text = info.NumFaces.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseOutput_Click(object sender, EventArgs e)
        {
            if(dlgOutputFolder.ShowDialog() == DialogResult.OK)
            {
                txtOuputFolder.Text = dlgOutputFolder.SelectedPath;
            }
        }

        private Boolean AreAllOptionsSet()
        {
            // Check if anything is checked
            if (!chkJava.Checked) return false;

            return true;
        }

        private void EnableGenerateCommand(object sender, EventArgs e)
        {
            btnGenerate.Enabled = AreAllOptionsSet();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!AreAllOptionsSet())
                return;

            JavaCodeGenerator generator = new JavaCodeGenerator(mParser.getInfo(), mParser.getData());
            generator.CreateCode(txtOuputFolder.Text, txtBaseClassname.Text);
        }
    }
}
