using Navigator.Engine;
using Navigator.Loaders;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        private Manager Manager { get; }
        private ProfileLoader ProfileLoader { get; }

        public CMD(Manager manager, ProfileLoader profileLoader)
        {
            Manager = manager;
            ProfileLoader = profileLoader;
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e) => Manager.Start();
        private void StopButton_Click(object sender, EventArgs e) => Manager.Stop();
        private void LoadProfileButton_Click(object sender, EventArgs e) => ProfileLoader.LoadProfile(LoadProfileOFD);
        private void GUI_Load(object sender, EventArgs e)
        {

        }
        private void LoadProfileOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}