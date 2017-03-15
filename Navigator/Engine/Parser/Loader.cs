using Navigator.GUI;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using ZzukBot.Objects;

namespace Navigator.Engine.Parser
{
    public class Loader
    {
        private static Lazy<Loader> _instance = new Lazy<Loader>(() => new Loader());
        public static Loader Instance => _instance.Value;

        public void LoadJSON()
        {
            DialogResult result = CMD.Instance.LoadJSONOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(CMD.Instance.LoadJSONOFD.FileName);
                string json = sr.ReadToEnd();
                ProfileData waypoints = JsonConvert.DeserializeObject<ProfileData>(json);
            }
        }
    }
}