using Navigator.Engine;
using Navigator.GUI;
using System;
using System.ComponentModel.Composition;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Navigator
{
    [Export(typeof(IBotBase))]
    public class Navigator : IBotBase
    {
        public string Author { get; } = "krycess";
        public string Name { get; } = "Navigator";
        public int Version { get; } = 1;

        private DependencyMap map = new DependencyMap();

        public Navigator()
        {
            map.Add(this);
            map.Add(Navigation.Instance);
            map.Add(ObjectManager.Instance);
            map.Add(new Manager(map.Get<ObjectManager>()));
            map.Add(new ProfileLoader());
            map.Add(new Pather(map.Get<Navigation>(), map.Get<ObjectManager>(), map.Get<ProfileLoader>()));
            map.Add(new CMD(map.Get<ProfileLoader>(), map.Get<Pather>()));
        }

        public void ShowGui()
        {
            CMD settings = map.Get<CMD>();
            if (settings.Visible) {
                settings.Hide();
            }

            settings.Show();
        }

        public bool Start(Action parStopCallback) => map.Get<Manager>().Start(parStopCallback);

        public void Stop() => map.Get<Manager>().Stop();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void PauseBotbase(Action onPauseCallback)
        {
            map.Get<Pather>().Pause();
        }

        public bool ResumeBotbase()
        {
            map.Get<Pather>().Resume();
        }
    }
}