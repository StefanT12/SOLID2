using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public interface IPricing
    {
        public void RegisterPricing(VehicleType vehicleType, double price);
        public double GetPricing(VehicleType vehicleType);
    }
}
