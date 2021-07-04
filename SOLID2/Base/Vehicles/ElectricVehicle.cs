using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Vehicles
{
    public class ElectricVehicle : IVehicle, IElectricVehicle
    {
        private readonly double _rechargeLevel;

        public IVehicle.VehicleEnum VehicleType { get; private set; }

        public double BatteryLevel { get; private set; }

        public bool NeedsRecharge => BatteryLevel <= _rechargeLevel;

        public void Recharge()
        {
            BatteryLevel = 1;
        }

        public ElectricVehicle(double batteryLevel, IVehicle.VehicleEnum vehicleType, double rechargeLevel)
        {
            BatteryLevel = batteryLevel;
            _rechargeLevel = rechargeLevel;
            VehicleType = vehicleType;
        }
    }
}
