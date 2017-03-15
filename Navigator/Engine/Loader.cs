using Navigator.GUI;
using System;
//using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Loader
    {
        private static Lazy<Loader> _instance = new Lazy<Loader>(() => new Loader());
        public static Loader Instance => _instance.Value;

        private int i;
        private int x;
        private int y;
        private int z;

        public Location[] waypoints;

        public void LoadXML()
        {
            /*DialogResult result = CMD.Instance.LoadXMLOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = CMD.Instance.LoadXMLOFD.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                }
                catch (IOException)
                {

                }*/
            DialogResult result = CMD.Instance.LoadXMLOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] doc = XDocument.Load(CMD.Instance.LoadXMLOFD.FileName).Element("Hotspots").Element("Hotspot").Descendants("X").Select(element => element.Value).ToArray();
            }
            waypoints[i] = new Location(x, y, z);
        }
    }
}