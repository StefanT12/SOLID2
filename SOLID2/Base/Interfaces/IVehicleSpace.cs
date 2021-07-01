using System;

namespace SOLID2.Base
{
    [Flags]
    public enum VehicleType
    {
        Car = 0,
        Van = 1,
        Truck = 2,
        Bus = 4
    }
    public interface IVehicleSpace
    {
        public bool Occupied { get; }
        public IVehicle Vehicle { get; }
        public void Occupy(IVehicle vehicle);
    }
}