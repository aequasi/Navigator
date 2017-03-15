using System;
using System.Runtime.Serialization;
using ZzukBot.Objects;

namespace Navigator.Engine.Parser
{
    public class Hotspot
    {
        private static Lazy<Hotspot> _instance = new Lazy<Hotspot>(() => new Hotspot());
        public static Hotspot Instance => _instance.Value;
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Type { get; set; }
        public Location[] waypoints { get; set; }
        int i;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            waypoints[i] = new Location(X, Y, Z);
        }
    }
}