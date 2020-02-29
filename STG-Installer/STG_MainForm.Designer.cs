namespace STG_Installer
{
    partial class STG_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ElementPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ElementPanel
            // 
            this.ElementPanel.Location = new System.Drawing.Point(0, 0);
            this.ElementPanel.Name = "ElementPanel";
            this.ElementPanel.Size = new System.Drawing.Size(200, 100);
            this.ElementPanel.TabIndex = 0;
            // 
            // STG_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ElementPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "STG_MainForm";
            this.Text = "Star Trek Generations - Alternative Installer";
            this.Load += new System.EventHandler(this.STG_MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel ElementPanel;
    }
}

