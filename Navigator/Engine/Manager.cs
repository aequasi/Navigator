using System;
using ZzukBot.Game.Statics;

namespace Navigator.Engine
{
    public class Manager
    {
        private ObjectManager ObjectManagerInstance { get; }

        // What is this for?
        private bool runBot = false;

        public Manager(ObjectManager objectManager)
        {
            ObjectManagerInstance = objectManager;
        }

        public bool Start(Action parCallback)
        {
            return !ObjectManagerInstance.IsIngame ? runBot = false : !runBot;
        }

        public void Stop()
        {

        }
    }
}