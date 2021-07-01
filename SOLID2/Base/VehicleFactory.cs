using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public static class VehicleFactory
    {
        public static IVehicle GasCar(double gasLevel)
        {
            var gas = new Gas(gasLevel);

            return new Vehicle() { Fuel = gas, VehicleType = VehicleType.Car };
        }

        public static IVehicle Truck(double gasLevel)
        {
            var gas = new Gas(gasLevel);

            return new Vehicle() { Fuel = gas, VehicleType = VehicleType.Truck };
        }

        public static IVehicle Bus(double gasLevel)
        {
            var gas = new Gas(gasLevel);

            return new Vehicle() { Fuel = gas, VehicleType = VehicleType.Bus };
        }
    }
}
