using Navigator.Loaders;
using System;
using System.Collections.Generic;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private Navigation NavigationInstance { get; }
        private ObjectManager OMInstance { get; }
        private ProfileLoader ProfileLoader { get; }
        private List<Location> waypoints;
        private int i = 0;
        private const float proximity = 50;

        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavigationInstance = navigation;
            OMInstance = objectManager;
            ProfileLoader = profileLoader;
            waypoints = ProfileLoader.Waypoints;
        }
        public void Traverse()
        {
            LocalPlayer player = OMInstance.Player;
            Location targetLocation = waypoints[i];

            // While the player is futher than IS_CLOSE_DISTANCE from the target location, calculate the path, and CTM to the first place possible.
            // This code is likely inefficent, unless zzuk is caching/memoizing the results of CalculatePath
            // If there is no path to the target location, we will throw an exception
            while (player.Position.GetDistanceTo2D(targetLocation) > proximity)
            {
                Location[] path = NavigationInstance.CalculatePath(player.MapId, player.Position, targetLocation, true);
                if (path.Length == 0)
                {
                    throw new Exception("No path to " + targetLocation);
                }
                player.CtmTo(path[0]);
            }
            player.CtmTo(waypoints[i]);
            i++;
        }
    }
}