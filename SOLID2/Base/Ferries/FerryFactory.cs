using System;

namespace SOLID2.Base
{
    public static class FerryFactory
    {
        public enum FerryType
        {
            Large = 8,
            Small = 6,
            Eco = 10
        }

        public static IFerry Create(string name, FerryType type) 
        {
            return new Ferry(name, (int)type);
        }
    }
}
