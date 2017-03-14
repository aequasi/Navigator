using Navigator.Engine;
using System;
using System.ComponentModel.Composition;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Navigator
{
    [Export(typeof(IBotBase))]
    class Navigator : IBotBase
    {
        public string Author { get; } = "krycess";
        public string Name { get; } = "Navigator";
        public int Version { get; } = 1;
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