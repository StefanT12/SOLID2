using System;

namespace SOLID2.Base
{
    public static class VehicleFactory
    {
        private static readonly Random _random;
        private static readonly IVehicle.VehicleEnum[] _vehicEnumVals;

        public static IVehicle RandomVehicle()
        {
  
            return new Vehicle()
            {
                Fuel = new Gas(_random.NextDouble()),
                VehicleType = (IVehicle.VehicleEnum)_vehicEnumVals.GetValue(_random.Next(_vehicEnumVals.Length))
            };
        }
        static VehicleFactory()
        {
            _random = new Random();
            _vehicEnumVals = (IVehicle.VehicleEnum[])Enum.GetValues(typeof(IVehicle.VehicleEnum));
        }

    }
}
