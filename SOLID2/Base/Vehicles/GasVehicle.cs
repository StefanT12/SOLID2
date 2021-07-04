using SOLID2.Base.Vehicles.Interfaces;
using System;

namespace SOLID2.Base
{
    public class GasVehicle : IGasVehicle, IVehicle
    {
        private readonly double _refuelLevel;

        public double FuelLevel { get; private set; }

        public bool NeedsRefueling => FuelLevel <= _refuelLevel;

        public IVehicle.VehicleEnum VehicleType { get; private set; }

        public void Refuel()
        {
            FuelLevel = 1;
        }

        public GasVehicle(double fuelLevel, IVehicle.VehicleEnum vehicleType, double refuelLevel)
        {
            FuelLevel = fuelLevel;
            VehicleType = vehicleType;
            _refuelLevel = refuelLevel;
        }
    }
}
