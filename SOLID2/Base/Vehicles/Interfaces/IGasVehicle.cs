using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Vehicles.Interfaces
{
    public interface IGasVehicle
    {
        public double FuelLevel { get; }
        public bool NeedsRefueling { get; }
        public void Refuel();
    }
}
