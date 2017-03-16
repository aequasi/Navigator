using Navigator.Loaders.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public List<Location> Waypoints;

        public void LoadProfile(OpenFileDialog dialog)
        {
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ProfileData = JsonConvert.DeserializeObject<ProfileData>(GetJson(dialog));

                Waypoints = ProfileData.Profile.Hotspots.Select(x => x.Location).ToList();
            }
        }
        private string GetJson(OpenFileDialog dialog)
        {
            string content = new StreamReader(dialog.FileName).ReadToEnd();
            if (dialog.SafeFileName.EndsWith(".xml"))
            {
                content = ConvertXmlToJson(dialog.SafeFileName, content);
            }
            return content;
        }
        private string ConvertXmlToJson(string profileName, string content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://profile-converter.herokuapp.com/xml/{profileName}");
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(content);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            throw new Exception("Could not convert XML to JSON: " + response.ToString());
        }
    }
}