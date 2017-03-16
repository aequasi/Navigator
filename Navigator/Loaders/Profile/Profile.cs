using System.Collections.Generic;

namespace Navigator.Loaders.Profile
{
    public class Profile
    {
        public List<Hotspot> Hotspots { get; set; }
        public List<Hotspot> VendorHotspots { get; set; }
        public List<Hotspot> GhostHotspots { get; set; }
        public List<Hotspot> Repair { get; set; }
    }
}