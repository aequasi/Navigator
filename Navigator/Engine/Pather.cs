using System;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Pather
    {
        private static Lazy<Pather> _instance = new Lazy<Pather>(() => new Pather());
        public static Pather Instance => _instance.Value;
        public void Move()
        {
            var player = ObjectManager.Instance.Player;
            var target = ObjectManager.Instance.Target;
            Location curPoint = player.Position;
            Location endPoint = target.Position;
            var path = Navigation.Instance.CalculatePath(ObjectManager.Instance.Player.MapId, curPoint, endPoint,
                true);
            player.CtmTo(endPoint);
        }
    }
}
