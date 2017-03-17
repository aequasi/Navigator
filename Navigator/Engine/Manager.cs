using System;
using System.Threading;

namespace Navigator.Engine
{
    public class Manager
    {
        private Pather Pather { get; }
        private Action stopCallback;
        private bool running;

        public Manager(Pather pather)
        {
            Pather = pather;
        }
        public bool Start(Action onStopCallback)
        {
            running = true;
            stopCallback = onStopCallback;
            Pulse();
            return true;
        }
        public void Stop()
        {
            running = false;
        }
        public void Dispose()
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
            while (running)
            {
                Pather.Traverse();
                Thread.Sleep(50);
            }
            stopCallback();
        }
    }
}