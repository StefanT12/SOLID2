
using SOLID2.Base.Vehicles.Interfaces;

namespace SOLID2.Base
{

    public interface IFerry
    {
        public string Id { get; }
        public void Park(IVehicle vehicle);
        public void PurgeLastVehicle();
        public bool IsFull { get; }
        public int Size { get; }
    }
}
