﻿using Navigator.Engine;
using Navigator.GUI;
using System;
using System.ComponentModel.Composition;
using ZzukBot.Game.Statics;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Navigator
{
    [Export(typeof(IBotBase))]
    public class Navigator : IBotBase
    {
        private DependencyMap map = new DependencyMap();

        public Navigator()
        {
            map.Add(Navigation.Instance);
            map.Add(ObjectManager.Instance);
            map.Add(new Manager(map.Get<ObjectManager>(), map.Get<Pather>()));
            map.Add(new ProfileLoader());
            map.Add(new Pather(map.Get<Navigation>(), map.Get<ObjectManager>(), map.Get<ProfileLoader>()));
            map.Add(new CMD(map.Get<Manager>(), map.Get<ProfileLoader>()));
        }
        public string Author { get; } = "krycess";
        public string Name { get; } = "Navigator";
        public int Version { get; } = 1;
        public void ShowGui()
        {
            CMD settings = map.Get<CMD>();
            if (settings.Visible)
                settings.Hide();
            settings.Show();
        }
        public bool Start(Action onStopCallback) => map.Get<Manager>().Start();
        public void Stop() => map.Get<Manager>().Stop();
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void PauseBotbase(Action onPauseCallback) => map.Get<Manager>().Pause();
        public bool ResumeBotbase() => map.Get<Manager>().Resume();
    }
}