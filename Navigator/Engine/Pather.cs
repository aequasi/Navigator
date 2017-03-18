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

            player.CtmTo(GetPathPoint());
            //Logger.Instance.Log(GetPathPoint().ToString());
        }
        public Location GetClosestWaypoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
            Location closestWaypoint = ProfileLoader.waypoints.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestWaypoint));

            return ProfileLoader.waypoints[index];
        }
        public Location GetNextClosestWaypoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
            Location closestWaypoint = ProfileLoader.waypoints.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestWaypoint)) + 1;
            if (index == ProfileLoader.waypoints.Count)
                index = 0;

            return ProfileLoader.waypoints[index];
        }
        public Location GetPathPoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
            Location[] pathArray;
            List<Location> pathList;
            Location closestWaypoint;
            int index;

            if (playerPos.GetDistanceTo(GetClosestWaypoint()) <= 2.0)
            {
                pathArray = Navigation.CalculatePath(player.MapId, playerPos, GetClosestWaypoint(), true);
                pathList = pathArray.ToList();

                closestWaypoint = pathList.OrderBy(x => playerPos.GetDistanceTo(x)).First();
                index = pathList.FindIndex(x => x.Equals(closestWaypoint)) + 1;
                if (index == pathList.Count)
                    index = 0;
                return pathList[index];
            }
            else if (playerPos.GetDistanceTo(GetClosestWaypoint()) > 2.0)
            {
                pathArray = Navigation.CalculatePath(player.MapId, playerPos, GetNextClosestWaypoint(), true);
                pathList = pathArray.ToList();

                closestWaypoint = pathList.OrderBy(x => playerPos.GetDistanceTo(x)).First();
                index = pathList.FindIndex(x => x.Equals(closestWaypoint)) + 1;
                if (index == pathList.Count)
                    index = 0;
                return pathList[index];
            }
            else
                throw new NullReferenceException("GetPathPoint() returned null");
        }
    }
}