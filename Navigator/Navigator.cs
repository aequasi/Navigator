using Navigator.Engine;
using Navigator.GUI;
using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Navigator
{
    [Export(typeof(IBotBase))]
    class Navigator : IBotBase
    {
        public string Author { get; } = "krycess";
        public string Name { get; } = "Navigator";
        public int Version { get; } = 1;

        Form cmd = new CMD();

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
            cmd.Dispose();
            cmd = new CMD();
            cmd.Show();
        }
        public bool Start(Action parStopCallback)
        {
            return Manager.Instance.Start(parStopCallback);
        }
        public void Stop()
        {
            Manager.Instance.Stop();
        }
    }
}