using Navigator.Engine;
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

        Form gui = new GUI.GUI();

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
            gui.Dispose();
            gui = new GUI.GUI();
            gui.Show();
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