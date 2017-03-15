using System;
using System.Runtime.InteropServices;

namespace Navigator.Debugger
{
    public class Terminal
    {
        private static Lazy<Terminal> _instance = new Lazy<Terminal>(() => new Terminal());
        public static Terminal Instance => _instance.Value;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool AllocConsole();

        public void OpenConsole()
        {
            AllocConsole();
        }
    }
}