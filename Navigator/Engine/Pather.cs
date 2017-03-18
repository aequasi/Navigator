using Navigator.Debugger;
using Navigator.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private Navigation Navigation { get; }
        private ObjectManager ObjectManager { get; }
        private ProfileLoader ProfileLoader { get; }

        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            Navigation = navigation;
            ObjectManager = objectManager;
            ProfileLoader = profileLoader;
        }
        public void Traverse()
        {
            LocalPlayer player = ObjectManager.Player;

            player.CtmTo(Path());
        }
        public Location GetNextWaypoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
            Location closestWaypoint = ProfileLoader.waypoints.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestWaypoint)) + 1;

            while (index == ProfileLoader.waypoints.Count())
                return ProfileLoader.waypoints[1];

            return ProfileLoader.waypoints[index];
        }
        public Location Path()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
            Location[] pathArray = Navigation.CalculatePath(player.MapId, playerPos, GetNextWaypoint(), true);
            List<Location> pathList = pathArray.ToList();
            Location closestWaypoint = pathList.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = pathList.FindIndex(x => x.Equals(closestWaypoint)) + 1;

            return pathList[index];
        }
    }
}