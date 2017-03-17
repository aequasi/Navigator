using Navigator.Loaders.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZzukBot.Objects;

namespace Navigator.Loaders
{
    public class ProfileLoader
    {
        private Loader Loader { get; }
        public ProfileData ProfileData { get; internal set; }
        public List<Location> Waypoints { get { return ProfileData.Profile.Hotspots.Select(x => x.Location).ToList(); } }
        public int index = 0;

        public ProfileLoader(Loader loader)
        {
            Loader = loader;
        }
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
                index = 0;
            }
        }
    }
}