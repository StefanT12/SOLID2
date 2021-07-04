using SOLID2.Base.Vehicles;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public static class VehicleFactory
    {
        private static readonly Random _random;
        private static readonly IVehicle.VehicleEnum[] _vehicEnumVals;
        public static IVehicle RandomVehicle()
        {
            var rVehicleType = (IVehicle.VehicleEnum)_vehicEnumVals.GetValue(_random.Next(_vehicEnumVals.Length));
            
            //def response, a car based on gas
            IVehicle rVehicle = new GasVehicle(_random.NextDouble(), IVehicle.VehicleEnum.Car, 0.1); ;
            
            switch (rVehicleType)
            {
                case IVehicle.VehicleEnum.Bus:
                    rVehicle = new GasVehicle(_random.NextDouble(), rVehicleType, 0.1);
                    break;
                case IVehicle.VehicleEnum.Car:
                    rVehicle = new GasVehicle(_random.NextDouble(), rVehicleType, 0.1);
                    break;
                case IVehicle.VehicleEnum.Electric:
                    rVehicle = new ElectricVehicle(_random.NextDouble(), rVehicleType, 0.1);
                    break;
                case IVehicle.VehicleEnum.Hybrid:
                    rVehicle = new HybridVehicle(_random.NextDouble(), 0.5, _random.NextDouble(), 0.5, rVehicleType);
                    break;
                case IVehicle.VehicleEnum.Truck:
                    rVehicle = new CargoVehicle(_random.NextDouble(), rVehicleType, 0.1, _random.NextDouble() >= 0.5);
                    break;
                case IVehicle.VehicleEnum.Van:
                    rVehicle = new CargoVehicle(_random.NextDouble(), rVehicleType, 0.1, _random.NextDouble() >= 0.5);
                    break;
            }

            return rVehicle;
        }
        static VehicleFactory()
        {
            _random = new Random();
            _vehicEnumVals = (IVehicle.VehicleEnum[])Enum.GetValues(typeof(IVehicle.VehicleEnum));
        }
    }
}
