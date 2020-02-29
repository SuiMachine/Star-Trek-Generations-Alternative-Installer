namespace STG_Installer.Pages
{
    partial class Panel1_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel1_Info));
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.B_Browse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(460, 411);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(75, 23);
            this.B_Next.TabIndex = 0;
            this.B_Next.Text = "Install ->";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(541, 411);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(205, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 120);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::STG_Installer.Properties.Resources.Sidebar;
            this.pictureBox1.InitialImage = global::STG_Installer.Properties.Resources.Sidebar;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Directory:";
            // 
            // TB_Path
            // 
            this.TB_Path.Location = new System.Drawing.Point(263, 305);
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(272, 20);
            this.TB_Path.TabIndex = 6;
            this.TB_Path.Text = "D:\\StarTrekGenerations";
            // 
            // B_Browse
            // 
            this.B_Browse.Location = new System.Drawing.Point(541, 303);
            this.B_Browse.Name = "B_Browse";
            this.B_Browse.Size = new System.Drawing.Size(75, 23);
            this.B_Browse.TabIndex = 7;
            this.B_Browse.Text = "Browse";
            this.B_Browse.UseVisualStyleBackColor = true;
            this.B_Browse.Click += new System.EventHandler(this.B_Browse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "* - paths can not contain whitespaces and special characters";
            // 
            // Panel1_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.B_Browse);
            this.Controls.Add(this.TB_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Next);
            this.Name = "Panel1_Info";
            this.Size = new System.Drawing.Size(620, 440);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Button B_Browse;
        private System.Windows.Forms.Label label4;
    }
}
