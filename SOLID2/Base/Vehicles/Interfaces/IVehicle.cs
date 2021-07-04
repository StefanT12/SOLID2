using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Vehicles.Interfaces
{
    public interface IVehicle
    {
        [Flags]
        public enum VehicleEnum
        {
            Car = 1,
            Van = 2,
            Truck = 4,
            Bus = 8,
            Hybrid = 16,
            Electric = 32
        }

        public VehicleEnum VehicleType { get; }
    }

    public class Vehicle : IVehicle
    {
        public IVehicle.VehicleEnum VehicleType { get; set; }
    }
}
