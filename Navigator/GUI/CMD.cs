using Navigator.Loaders;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        private Navigator Navigator { get; }
        private ProfileLoader ProfileLoader { get; }
        private void onStopCallback() { }

        public CMD(Navigator navigator, ProfileLoader profileLoader)
        {
            Navigator = navigator;
            ProfileLoader = profileLoader;
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {

        }
        private void StartButton_Click(object sender, EventArgs e) => Navigator.Start(onStopCallback);
        private void StopButton_Click(object sender, EventArgs e) => Navigator.Stop();
        private void LoadProfileButton_Click(object sender, EventArgs e) => ProfileLoader.LoadProfile(LoadProfileOFD);
        private void LoadProfileOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}