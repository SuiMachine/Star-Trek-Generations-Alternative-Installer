using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STG_Installer.Pages
{
    public partial class Panel1_Info : UserControl
    {
        private STG_MainForm _parent;

        public Panel1_Info(STG_MainForm _parent)
        {
            InitializeComponent();
            this._parent = _parent;
        }

        private void B_Next_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(TB_Path.Text))
                Directory.CreateDirectory(TB_Path.Text);

            _parent.SetControl(new Pages.Panel2_Installation(_parent, TB_Path.Text));
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, you want to cancel the installation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
                _parent.Exit();
        }

        private void B_Browse_Click(object sender, EventArgs e)
        {
            var tempPath = Directory.Exists(TB_Path.Text) ? TB_Path.Text : "C:\\";

            FolderBrowserDialog fd = new FolderBrowserDialog() { SelectedPath = tempPath, ShowNewFolderButton = true, Description = "Select installation folder" };
            var result = fd.ShowDialog();
            if(result == DialogResult.OK)
            {
                TB_Path.Text = fd.SelectedPath;
            }
        }
    }
}
