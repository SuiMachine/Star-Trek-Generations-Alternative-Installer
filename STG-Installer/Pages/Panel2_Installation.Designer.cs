namespace STG_Installer.Pages
{
    partial class Panel2_Installation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InstallationProgressBar = new System.Windows.Forms.ProgressBar();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.RB_Output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // InstallationProgressBar
            // 
            this.InstallationProgressBar.Location = new System.Drawing.Point(3, 385);
            this.InstallationProgressBar.Name = "InstallationProgressBar";
            this.InstallationProgressBar.Size = new System.Drawing.Size(614, 23);
            this.InstallationProgressBar.TabIndex = 0;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(539, 414);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 1;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // RB_Output
            // 
            this.RB_Output.Location = new System.Drawing.Point(3, 3);
            this.RB_Output.Name = "RB_Output";
            this.RB_Output.Size = new System.Drawing.Size(614, 376);
            this.RB_Output.TabIndex = 2;
            this.RB_Output.Text = "";
            this.RB_Output.TextChanged += new System.EventHandler(this.RB_Output_TextChanged);
            // 
            // Panel2_Installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RB_Output);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.InstallationProgressBar);
            this.Name = "Panel2_Installation";
            this.Size = new System.Drawing.Size(620, 440);
            this.Load += new System.EventHandler(this.Panel2_Installation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar InstallationProgressBar;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.RichTextBox RB_Output;
    }
}
