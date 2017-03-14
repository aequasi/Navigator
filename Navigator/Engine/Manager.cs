using System;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;

namespace Navigator.Engine
{
    public class Manager
    {
        private static Lazy<Manager> _instance = new Lazy<Manager>(() => new Manager());
        public static Manager Instance => _instance.Value;
        private bool _runBot = false;
        public bool Start(Action parCallback)
        {
            if (!ObjectManager.Instance.IsIngame)
            {
                return _runBot = false;
            }
            if (_runBot)
            {
                return false;
            }
            var player = ObjectManager.Instance.Player;
            var target = ObjectManager.Instance.Target;
            Location curPoint = player.Position;
            Location endPoint = target.Position;
            var path = Navigation.Instance.CalculatePath(ObjectManager.Instance.Player.MapId, curPoint, endPoint,
                true);
            player.CtmTo(endPoint);
            return true;
        }
        public void Stop()
        {
            return;
        }
    }
}