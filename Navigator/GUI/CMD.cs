using Navigator.Engine;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        public CMD()
        {
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {

        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Pather.Instance.Traverse();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {

        }
        private void LoadJSONButton_Click(object sender, EventArgs e)
        {
            Loader.Instance.LoadJSON();
        }
        private void LoadJSONOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}