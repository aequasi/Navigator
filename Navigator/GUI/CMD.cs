using Navigator.Engine;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Navigator.GUI
{
    public partial class CMD : Form
    {
        private Manager Manager { get; }
        private Pather Pather { get; }
        private ProfileLoader ProfileLoader { get; }

        public CMD(Manager manager, Pather pather, ProfileLoader profileLoader)
        {
            Pather = pather;
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