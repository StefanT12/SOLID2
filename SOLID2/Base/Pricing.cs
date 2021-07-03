using System;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class Pricing : IPricing
    {
        private IDictionary<IVehicle.VehicleEnum, double> _pricePerType;

        /// <summary>
        /// returns negative if the price is not registered
        /// </summary>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        public double GetPricing(IVehicle.VehicleEnum VehicleType)
        {
            double price = -1;
            bool found = _pricePerType.TryGetValue(VehicleType, out price);

            if (!found)
            {
                throw new NullReferenceException("Type: " + VehicleType.ToString() + "does not have its price registered!");
            }
            return price;
        }
        public Pricing(IDictionary<IVehicle.VehicleEnum, double> pricePerType)
        {
            _pricePerType = pricePerType;
        }
    }
}
