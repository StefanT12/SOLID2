using System;

namespace SOLID2.Base
{
    public static class VehicleFactory
    {
        public static IVehicle GasCar(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel),
                VehicleType= IVehicle.VehicleEnum.Car 
            };
        }

        public static IVehicle Truck(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel), 
                VehicleType = IVehicle.VehicleEnum.Truck 
            };
        }

        public static IVehicle Bus(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel), 
                VehicleType = IVehicle.VehicleEnum.Bus 
            };
        }

        public static IVehicle RandomVehicle()
        {
            var random = new Random();
            Array vehicEnumVals = Enum.GetValues(typeof(IVehicle.VehicleEnum));
            return new Vehicle()
            {
                Fuel = new Gas(random.NextDouble()),
                VehicleType = (IVehicle.VehicleEnum)vehicEnumVals.GetValue(random.Next(vehicEnumVals.Length))
        };
        }
    }
}
