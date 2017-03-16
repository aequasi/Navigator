using Navigator.Loaders;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private Navigation NavigationInstance { get; }
        private ObjectManager OMInstance { get; }
        private ProfileLoader ProfileLoader { get; }
        private Location[] waypoints;
        private int i = 0;

        public Pather(Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            NavigationInstance = navigation;
            OMInstance = objectManager;
            ProfileLoader = profileLoader;
            waypoints = ProfileLoader.waypoints;
        }
        public void Traverse()
        {
            LocalPlayer player = OMInstance.Player;
            Location curPpint = player.Position;
            Location targetLocation = waypoints[i];

            player.CtmTo(targetLocation);
            i++;
        }
    }
}