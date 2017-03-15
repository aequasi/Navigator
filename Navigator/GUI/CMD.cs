using Navigator.Engine;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        public string file;
        public CMD()
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
            Loader.Instance.LoadXML();
        }
        private void LoadXMLOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}