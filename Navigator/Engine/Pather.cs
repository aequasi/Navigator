﻿using Navigator.Loaders;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private Navigation NavInstance { get; }
        private ObjectManager OMInstance { get; }
        private ProfileLoader ProfileLoader { get; }
        private Location[] waypoints;
        int i = 0;
        
        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavInstance = navigation;
            OMInstance = objectManager;
            ProfileLoader = profileLoader;
            waypoints = ProfileLoader.waypoints;
        }
        public void Traverse()
        {
            var player = OMInstance.Player;
            Location targetLocation = waypoints[i];
            player.CtmTo(targetLocation);
            i++;
        }
    }
}