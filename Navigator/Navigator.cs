using Navigator.Engine;
using System;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Navigator
{
    public class Navigator : IBotBase
    {
        string author = "krycess";
        string name = "Navigator";
        int version = 1;
        public string Author
        {
            get
            {
                return author;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Version
        {
            get
            {
                return version;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void PauseBotbase(Action onPauseCallback)
        {
            throw new NotImplementedException();
        }
        public bool ResumeBotbase()
        {
            throw new NotImplementedException();
        }
        public void ShowGui()
        {
            throw new NotImplementedException();
        }
        public bool Start(Action parStopCallback)
        {
            Manager.Instance.Start(parStopCallback);
            return true;
        }
        public void Stop()
        {
            Manager.Instance.Stop();
        }
    }
}