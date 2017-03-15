using Navigator.Engine;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        private ProfileLoader ProfileLoader { get; }
        private Pather Pather { get; }

        public CMD(ProfileLoader profileLoader, Pather pather)
        {
            ProfileLoader = profileLoader;
            Pather = pather;
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) => Pather.Traverse();

        private void StopButton_Click(object sender, EventArgs e) => Pather.Stop();

        private void LoadProfileButton_Click(object sender, EventArgs e) => ProfileLoader.LoadProfile(LoadProfileOFD);

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void LoadProfileOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}