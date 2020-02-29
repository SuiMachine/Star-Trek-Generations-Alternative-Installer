using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STG_Installer
{
    public partial class STG_MainForm : Form
    {
        UserControl control;

        public STG_MainForm()
        {
            Logger.PrepareLog();
            Logger.AppendLog("Starting log!");
            InitializeComponent();
        }

        private void STG_MainForm_Load(object sender, EventArgs e)
        {
            Logger.AppendLog("Initializing first page!");
            SetControl(new Pages.Panel1_Info(this));
            Logger.AppendLog("Set controls for first page!");
        }

        public void SetControl(UserControl control)
        {
            ElementPanel.Controls.Clear();
            this.control = control;
            ElementPanel.Size = control.Size;
            ElementPanel.Location = new Point(0, 0);
            ElementPanel.Controls.Add(control);
        }

        public void Exit()
        {
            ElementPanel.Controls.Clear();
            this.Close();
        }
    }
}
