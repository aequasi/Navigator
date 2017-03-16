using System;

namespace Navigator.Engine
{
    public class Manager
    {
        private Pather Pather { get; }
        private Action stopCallback;

        public Manager(Pather pather)
        {
            Pather = pather;
        }
        public bool Start(Action onStopCallback)
        {
            Pather.Traverse();
            stopCallback = onStopCallback;
            return true;
        }
        public void Stop()
        {

        }
        public void Pause()
        {

        }
        public bool Resume()
        {
            return true;
        }
        private void Pulse()
        {
            stopCallback();
        }
    }
}