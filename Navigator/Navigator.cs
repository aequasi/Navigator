using Navigator.DependencyMap;
using Navigator.Engine;
using Navigator.GUI;
using Navigator.Loaders;
using Navigator.Loaders.Profile;
using System;
using System.ComponentModel.Composition;
using ZzukBot.ExtensionFramework.Interfaces;
using ZzukBot.Game.Statics;

namespace Navigator
{
    [Export(typeof(IBotBase))]
    public class Navigator : IBotBase
    {
        private Router r = new Router();

        public Navigator()
        {
            r.Add(this);
            r.Add(Navigation.Instance);
            r.Add(ObjectManager.Instance);
            r.Add(new Loader());
            r.Add(new ProfileLoader(r.Get<Loader>()));
            r.Add(new Pather(r.Get<Navigation>(), r.Get<ObjectManager>(), r.Get<ProfileLoader>()));
            r.Add(new Manager(r.Get<Pather>()));
            r.Add(new CMD(r.Get<Navigator>(), r.Get<ProfileLoader>()));
        }
        public string Author { get; } = "krycess";
        public string Name { get; } = "Navigator";
        public int Version { get; } = 1;
        public void ShowGui()
        {
            CMD settings = r.Get<CMD>();
            if (settings.Visible)
                settings.Hide();
            settings.Show();
        }
        public bool Start(Action onStopCallback) => r.Get<Manager>().Start(onStopCallback);
        public void Stop() => r.Get<Manager>().Stop();
        public void Dispose() => r.Get<Manager>().Dispose();
        public void PauseBotbase(Action onPauseCallback) => r.Get<Manager>().Pause();
        public bool ResumeBotbase() => r.Get<Manager>().Resume();
    }
}