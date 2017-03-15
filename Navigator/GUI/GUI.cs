using Navigator.Engine;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {

        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Pather.Instance.Move();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {

        }
        private void LoadXMLButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LoadXMLOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = LoadXMLOFD.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                }
                catch (IOException)
                {

                }
            }
        }
        private void LoadXMLOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}