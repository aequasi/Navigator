using System;

namespace Navigator.GUI
{
    partial class CMD
    {
        private static Lazy<CMD> _instance = new Lazy<CMD>(() => new CMD());
        public static CMD Instance => _instance.Value;

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
			this.StartButton = new System.Windows.Forms.Button();
			this.StopButton = new System.Windows.Forms.Button();
			this.LoadProfileButton = new System.Windows.Forms.Button();
			this.LoadProfileOFD = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(174, 348);
			this.StartButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(112, 35);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(296, 348);
			this.StopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(112, 35);
			this.StopButton.TabIndex = 1;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// LoadProfileButton
			// 
			this.LoadProfileButton.Location = new System.Drawing.Point(18, 348);
			this.LoadProfileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.LoadProfileButton.Name = "LoadProfileButton";
			this.LoadProfileButton.Size = new System.Drawing.Size(112, 35);
			this.LoadProfileButton.TabIndex = 2;
			this.LoadProfileButton.Text = "Load Profile";
			this.LoadProfileButton.UseVisualStyleBackColor = true;
			this.LoadProfileButton.Click += new System.EventHandler(this.LoadProfileButton_Click);
			// 
			// LoadProfileOFD
			// 
			this.LoadProfileOFD.FileName = "LoadProfile";
			this.LoadProfileOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadProfileOFD_FileOk);
			// 
			// CMD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 402);
			this.Controls.Add(this.LoadProfileButton);
			this.Controls.Add(this.StopButton);
			this.Controls.Add(this.StartButton);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "CMD";
			this.Text = "GUI";
			this.Load += new System.EventHandler(this.GUI_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button LoadProfileButton;
        public System.Windows.Forms.OpenFileDialog LoadProfileOFD;
    }
}