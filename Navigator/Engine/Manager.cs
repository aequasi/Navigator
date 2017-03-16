using System;
using ZzukBot.Game.Statics;

namespace Navigator.Engine
{
    public class Manager
    {
        private ObjectManager ObjectManagerInstance { get; }
        private Pather Pather { get; }
        public event EventHandler OnPaused;
        private bool IsPaused { get; set; } = false;
        private bool runBot = false;

        public Manager(ObjectManager objectManager, Pather pather)
        {
            ObjectManagerInstance = objectManager;
            Pather = pather;
        }
        public bool Start()
        {
            return !ObjectManagerInstance.IsIngame ? runBot = false : true;
        }
        public void Stop()
        {
            ObjectManagerInstance.Player.CtmStopMovement();
        }
        public void Pause()
        {
            IsPaused = true;
            OnPaused(this, new EventArgs());
        }
        public bool Resume()
        {
            IsPaused = false;
            Pather.Traverse();
            return true;
        }
    }
}