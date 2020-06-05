using System;

namespace Colors.Domain
{
    public class Color
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public ColorCode Code { get; set; }

    }
    public class ColorCode
    {
        public int[] RGBA { get; set; }
        public string Hex { get; set; }
    }
}
