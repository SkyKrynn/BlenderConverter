using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blender_Converter
{
    public partial class frmJavaOptions : Form
    {
        JavaOptions mOptions;

        public frmJavaOptions(JavaOptions options)
        {
            InitializeComponent();
            mOptions = options;
            if(mOptions != null)
            {
                txtPackageName.Text = options.Package;
                txtClassName.Text = options.ClassName;
            }
        }

        public JavaOptions GetOptions(JavaOptions options)
        {
            this.ShowDialog();
            return mOptions;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mOptions == null)
            {
                mOptions = new JavaOptions(txtPackageName.Text, txtClassName.Text);
            }
            else
            {
                mOptions.Package = txtPackageName.Text;
                mOptions.ClassName = txtClassName.Text;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
