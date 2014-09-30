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
        private ObjectFileReader mObjectFile;

        private JavaOptions mJavaOptions;

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
                txtBaseFilename.Text = Path.GetFileNameWithoutExtension(mInputFile);
                mObjectFile = new ObjectFileReader(mInputFile);
                showInfo(mObjectFile);
                showSampleData(mObjectFile);
                txtOuputFolder.Text = Path.GetDirectoryName(mInputFile);
                pnlMain.Enabled = true;
            }
        }

        private void showSampleData(ObjectFileReader objFile)
        {
            ModelData data = objFile.Data;
            lstData.Items.Clear();
            lstData.Items.Add("Model Data");
            lstData.Items.Add("P1: " + data.Positions[0,0] + "x " + data.Positions[0,1] + "y " + data.Positions[0,2] + "z");
            lstData.Items.Add("T1: " + data.Texels[0, 0] + "u " + data.Texels[0, 1] + "v");
            lstData.Items.Add("N1: " + data.Normals[0, 0] + "x " + data.Normals[0, 1] + "y " + data.Normals[0, 2] + "z");
            lstData.Items.Add("F1: " + data.Faces[0, 0] + "p " + data.Faces[0, 1] + "t " + data.Faces[0, 2] + "n");
        }

        private void clearInfo()
        {
            lblVertices.Text = "";
            lblPositions.Text = "";
            lblTexels.Text = "";
            lblNormals.Text = "";
            lblFaces.Text = "";
        }

        private void showInfo(ObjectFileReader info)
        {
            lblVertices.Text = info.Vertices.ToString();
            lblPositions.Text = info.Positions.ToString();
            lblTexels.Text = info.Texels.ToString();
            lblNormals.Text = info.Normals.ToString();
            lblFaces.Text = info.Texels.ToString();
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

            // For anything checked, options must be set
            if (chkJava.Checked && mJavaOptions == null) return false;

            return true;
        }

        private void EnableGenerateCommand(object sender, EventArgs e)
        {
            btnGenerate.Enabled = AreAllOptionsSet();
        }

        private void lnkJavaOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmJavaOptions form = new frmJavaOptions(mJavaOptions);
            mJavaOptions = form.GetOptions(mJavaOptions);
            EnableGenerateCommand(sender, e);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!AreAllOptionsSet())
                return;

            JavaCodeGenerator generator = new JavaCodeGenerator(mObjectFile.Info, mObjectFile.Data, mJavaOptions);
            generator.CreateCode(txtOuputFolder.Text, txtBaseFilename.Text);
        }
    }
}
