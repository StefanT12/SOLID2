using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public static class FerryRandNameGen
    {
        private static readonly string[] _ferryName1;
        private static readonly string[] _ferryName2;
        private static readonly Random _random;

        public static string CreateRandomName()
        {
            var i1 = _random.Next(0, _ferryName1.Length);
            var i2 = _random.Next(0, _ferryName2.Length);
            var i3 = _random.Next(0, 100000);
            return $"{_ferryName1[i1]}{_ferryName2[i2]}{i3}";
        }

        static FerryRandNameGen()
        {
            _ferryName1 = new string[] { "fast", "red", "master", "hollow", "sharp" };
            _ferryName2 = new string[] { "terminator", "spear", "runner", "dumbledore", "bird", "spiriter" };
            _random = new Random();
        }
    }
}
