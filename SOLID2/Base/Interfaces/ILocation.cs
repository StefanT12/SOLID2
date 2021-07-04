using SOLID2.Base.Vehicles.Interfaces;

namespace SOLID2.Base
{
    public interface ILocation 
    {
        public Result RunOperations(IEmployee employee, IVehicle vehicle);
    }
}
