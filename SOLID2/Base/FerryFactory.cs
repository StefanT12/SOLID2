using System;

namespace SOLID2.Base
{
    public static class FerryFactory
    {
        public enum FerryType
        {
            Large = 8,
            Small = 6
        }

        private static readonly string[] _ferryName1 =  { "fast", "red", "master", "hollow", "sharp"};
        private static readonly string[] _ferryName2 = { "terminator", "spear", "runner", "dumbledore", "bird", "spiriter" };

        public static IFerry Create(string name, FerryType type) 
        {
            return new Ferry($"{name}_{type}", (int)type);
        }

        public static IFerry CreateRandom(FerryType type)
        {
            var random = new Random();
            var i1 = random.Next(0, _ferryName1.Length);
            var i2 = random.Next(0, _ferryName2.Length);
            var i3 = random.Next(0, 100000);
            return new Ferry($"{_ferryName1[i1]}{_ferryName2[i2]}{i3}_{type}", (int)type);
        }
    }
}
