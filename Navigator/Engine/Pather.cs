using System;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private static Lazy<Pather> _instance = new Lazy<Pather>(() => new Pather());
        public static Pather Instance => _instance.Value;
        private Location[] waypoints = Loader.Instance.waypoints;
        int i;

        public void Traverse()
        {
            var player = ObjectManager.Instance.Player;
            Location curPoint = player.Position;
            Location endPoint = waypoints[i];
            var path = Navigation.Instance.CalculatePath(ObjectManager.Instance.Player.MapId, curPoint, endPoint, true);

            player.CtmTo(endPoint);
            i++;
        }
    }
}