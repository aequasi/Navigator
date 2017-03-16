using Navigator.Loaders.Model;
using Newtonsoft.Json;
using ProfileLoader;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ZzukBot.Objects;

namespace Navigator.Loaders
{
    public class ProfileLoader
    {
        public ProfileData ProfileData;
        public Location[] waypoints;

        public void LoadProfile(OpenFileDialog dialog)
        {
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ProfileData = Loader.LoadProfile(
                    dialog.FileName,
                    dialog.SafeFileName.Replace(".xml", "").Replace(".json", ""),
                    dialog.SafeFileName.EndsWith(".xml") ? ProfileExtension.XML : ProfileExtension.JSON,
                    ProfileType.Travel
                );
                waypoints = ProfileData.Profile.Hotspots.Select(x => x.Location).ToArray();
            }
        }
    }
}
