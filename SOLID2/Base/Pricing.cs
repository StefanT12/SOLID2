using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class Pricing : IPricing
    {
        private IDictionary<IVehicle.VehicleEnum, double> _pricePerType;
        public double GetPricing(IVehicle.VehicleEnum VehicleType)
        {
            if(!_pricePerType.TryGetValue(VehicleType, out double price))
            {
                return -1;
            }
            return _pricePerType[VehicleType];
        }
        public Pricing(IDictionary<IVehicle.VehicleEnum, double> pricePerType)
        {
            _pricePerType = pricePerType;
        }
    }
}
