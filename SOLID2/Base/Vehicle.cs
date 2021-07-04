using System;

namespace SOLID2.Base
{
    public interface IFuel
    {
        public double Level { get; }
        public void Refuel();
    }

    public class Gas : IFuel
    {
        public double Level { get; private set; }

        public void Refuel()
        {
            Level = 1;
        }

        public Gas(double level)
        {
            Level = level;
        }
    }

    public interface IVehicle
    {
        [Flags]
        public enum VehicleEnum
        {
            Car = 1,
            Van = 2,
            Truck = 4,
            Bus = 8
            //Hybrid = 8,
            //Electric = 9
        }

        public VehicleEnum VehicleType{ get; }
        public IFuel Fuel { get; }
    }

    public class Vehicle: IVehicle
    {
        public IVehicle.VehicleEnum VehicleType { get; set; }
        public IFuel Fuel { get; set; }
    }
}
