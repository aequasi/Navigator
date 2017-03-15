using Navigator.GUI;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZzukBot.Objects;

namespace Navigator.Engine.Parser
{
    public class Loader
    {
        private static Lazy<Loader> _instance = new Lazy<Loader>(() => new Loader());
        public static Loader Instance => _instance.Value;
        public Location[] waypoints;

        public void LoadJSON()
        {
            DialogResult result = CMD.Instance.LoadJSONOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(CMD.Instance.LoadJSONOFD.FileName);
                string json = sr.ReadToEnd();
                ProfileData profileData = JsonConvert.DeserializeObject<ProfileData>(json);
                waypoints = profileData.Profile.Hotspots.Select(x => x.Location).ToArray();
            }
        }
    }
}