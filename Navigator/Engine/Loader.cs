using Navigator.GUI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Navigator.Engine
{
    public class Loader
    {
        private static Lazy<Loader> _instance = new Lazy<Loader>(() => new Loader());
        public static Loader Instance => _instance.Value;

        public void LoadXML()
        {
            DialogResult result = CMD.Instance.LoadXMLOFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = CMD.Instance.LoadXMLOFD.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                }
                catch (IOException)
                {

                }
            }
        }
    }
}