using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Vehicles
{
    public class HybridVehicle : IVehicle, IElectricVehicle, IGasVehicle
    {
        public IVehicle.VehicleEnum VehicleType { get; private set; }

        private readonly double _refuelLevel;
        public double FuelLevel { get; private set; }
        public bool NeedsRefueling => BatteryLevel <= _rechargeLevel;

        private readonly double _rechargeLevel;
        public double BatteryLevel { get; private set; }
        public bool NeedsRecharge => FuelLevel <= _refuelLevel;

        
        public void Recharge()
        {
            BatteryLevel = 1;
        }

        public void Refuel()
        {
            FuelLevel = 1;
        }

        public HybridVehicle(double fuelLevel, double refuelLevel, double batteryLevel, double rechargeLevel, IVehicle.VehicleEnum vehicleType)
        {
            FuelLevel = fuelLevel;
            _refuelLevel = refuelLevel;
            _rechargeLevel = rechargeLevel;
            BatteryLevel = batteryLevel;
            VehicleType = vehicleType;
        }
    }
}
