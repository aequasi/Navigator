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

        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavigationInstance = navigation;
            ObjectManagerInstance = objectManager;
            ProfileLoader = profileLoader;
            Waypoints = ProfileLoader.Waypoints;
        }

        public void Traverse()
        {
            var player = ObjectManagerInstance.Player;

            // What is this path doing?
            var path = NavigationInstance.CalculatePath(player.MapId, player.Position, Waypoints[i], true);

            player.CtmTo(Waypoints[i]);
            i++;
        }

        public void Stop()
        {
            ObjectManagerInstance.Player.CtmStopMovement();
        }
    }
}