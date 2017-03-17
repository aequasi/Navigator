using Navigator.Debugger;
using Navigator.Loaders;
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
            Logger.Instance.Log(GetPathPoint().ToString());
        }
        public Location GetClosestWaypoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;
     
            Location closestStart = ProfileLoader.waypoints.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestStart)) + 1;
            if (index == ProfileLoader.waypoints.Count)
                index = 0;

            return ProfileLoader.waypoints[index];
        }
        public Location GetPathPoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;

            Location[] pathArray = Navigation.CalculatePath(player.MapId, playerPos, GetClosestWaypoint(), true);
            List<Location> pathList = pathArray.ToList();

            Location closestStart = pathList.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            int index = pathList.FindIndex(x => x.Equals(closestStart)) + 1;
            if (index == pathList.Count)
                index = 0;

            return pathList[index];
        }
    }
}