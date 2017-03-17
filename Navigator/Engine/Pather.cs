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
        
        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavInstance = navigation;
            OMInstance = objectManager;
            ProfileLoader = profileLoader;
        }
        public void Traverse()
        {
            var player = OMInstance.Player;
            Location targetLocation = ProfileLoader.waypoints[ProfileLoader.index++];
            player.CtmTo(targetLocation);
        }
    }
}