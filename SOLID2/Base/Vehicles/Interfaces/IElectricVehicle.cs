using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Vehicles.Interfaces
{
    public interface IElectricVehicle
    {
        public double BatteryLevel { get; }
        public bool NeedsRecharge { get; }
        public void Recharge();
    }
}
