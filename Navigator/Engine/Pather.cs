using Navigator.Debugger;
using Navigator.Loaders;
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
            Logger.Instance.Log(GetClosestWaypoint().ToString());
            player.CtmTo(GetClosestWaypoint());
        }
        public Location GetClosestWaypoint()
        {
            LocalPlayer player = ObjectManager.Player;
            Location playerPos = player.Position;

            Location closestStart = ProfileLoader.waypoints.OrderBy(x => playerPos.GetDistanceTo(x)).First();
            Logger.Instance.Log(closestStart.ToString());
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestStart)) + 1;
            Logger.Instance.Log(index.ToString());
            return ProfileLoader.waypoints[index];
        }
    }
}