using ZzukBot.Game.Statics;

namespace Navigator.Engine
{
    public class Manager
    {
        private ObjectManager ObjectManagerInstance { get; }
        private Pather Pather { get; }
        private bool IsPaused { get; set; } = false;

        public Manager(ObjectManager objectManager, Pather pather)
        {
            ObjectManagerInstance = objectManager;
            Pather = pather;
        }
        public bool Start()
        {
            Pather.Traverse();
            return true;
        }
        public void Stop()
        {
            ObjectManagerInstance.Player.CtmStopMovement();
        }
        public void Pause()
        {
            IsPaused = true;
        }
        public bool Resume()
        {
            IsPaused = false;
            Pather.Traverse();
            return true;
        }
    }
}