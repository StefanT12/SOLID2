namespace SOLID2.Base
{
    public static class FerryFactory
    {
        public enum FerryType
        {
            Large = 8,
            Small = 6
        }

        public static IFerry Create(string id, FerryType type)
        {
            return new Ferry(id, (int)type);
        }

        public static IFerry Create(string newId,IFerry ferry)
        {
            return new Ferry(newId, ferry.Size);
        }
    }
}
