using Navigator.Engine.Parser;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZzukBot.Objects;
using System.Collections.Generic;

namespace Navigator.Engine
{
    public class ProfileLoader
    {
        public ProfileData ProfileData;
        public List<Location> Waypoints;

        public void LoadProfile(OpenFileDialog dialog)
        {
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ProfileData = JsonConvert.DeserializeObject<ProfileData>((new StreamReader(dialog.FileName)).ReadToEnd());

                Waypoints = ProfileData.Profile.Hotspots.Select(x => x.Location).ToList();
            }
        }
    }
}