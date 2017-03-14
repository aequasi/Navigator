using Navigator.Engine;
using System;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Pather.Instance.Move();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {

        }
        private void GUI_Load(object sender, EventArgs e)
        {

        }
    }
}