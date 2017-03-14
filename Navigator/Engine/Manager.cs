using System;
using ZzukBot.Game.Statics;

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
            return true;
        }
        public void Stop()
        {

        }
    }
}