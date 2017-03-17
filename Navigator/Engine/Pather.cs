using Navigator.Debugger;
using Navigator.Loaders;
using System.Linq;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private LocalPlayer Player { get; }
        private Navigation Navigation { get; }
        private ObjectManager ObjectManager { get; }
        private ProfileLoader ProfileLoader { get; }

        public Pather(LocalPlayer player, Navigation navigation, ObjectManager objectManager, ProfileLoader profileLoader)
        {
            Navigation = navigation;
            ObjectManager = objectManager;
            ProfileLoader = profileLoader;
            Player = player;
        }
        public void Traverse()
        {
            Logger.Instance.Log(GetClosestWaypoint().ToString());
        }
        public Location GetClosestWaypoint()
        {
            Location closestStart = ProfileLoader.waypoints.OrderBy(x => Player.Position.GetDistanceTo(x)).First();
            Logger.Instance.Log(closestStart.ToString());
            int index = ProfileLoader.waypoints.FindIndex(x => x.Equals(closestStart)) + 1;
            Logger.Instance.Log(index.ToString());
            return ProfileLoader.waypoints[index];
        }
    }
}