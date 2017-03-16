using System;
using System.Collections.Generic;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private Navigation NavigationInstance { get; }
        private ObjectManager ObjectManagerInstance { get; }
        private ProfileLoader ProfileLoader { get; }
        private List<Location> Waypoints;
        private int i = 0;
        private const float IS_CLOSE_DISTANCE = 50;

        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavigationInstance = navigation;
            ObjectManagerInstance = objectManager;
            ProfileLoader = profileLoader;
            Waypoints = ProfileLoader.Waypoints;
        }
        public void Traverse()
        {
            LocalPlayer player = ObjectManagerInstance.Player;
            Location targetLocation = Waypoints[i];

            // While the player is futher than IS_CLOSE_DISTANCE from the target location, calculate the path, and CTM to the first place possible.
            // This code is likely inefficent, unless zzuk is caching/memoizing the results of CalculatePath
            // If there is no path to the target location, we will throw an exception
            while (player.Position.GetDistanceTo2D(targetLocation) > IS_CLOSE_DISTANCE)
            {
                Location[] path = NavigationInstance.CalculatePath(player.MapId, player.Position, targetLocation, true);
                if (path.Length == 0)
                {
                    throw new Exception("No path to " + targetLocation);
                }
                player.CtmTo(path[0]);
            }
            player.CtmTo(Waypoints[i]);
            i++;
        }
    }
}