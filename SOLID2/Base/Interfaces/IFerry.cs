
namespace SOLID2.Base
{

    public interface IFerry
    {
        public string Id { get; }
        public Result FillUpSpace(IVehicle vehicle);
        public bool IsFull { get; }
        public int Size { get; }
    }
}
