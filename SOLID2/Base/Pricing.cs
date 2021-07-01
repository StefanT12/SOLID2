using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Pricing : IPricing
    {
        private Dictionary<VehicleType, double> _pricePerType;

        /// <summary>
        /// returns negative if the price is not registered
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public double GetPricing(VehicleType vehicleType)
        {
            double price = -1;
            bool found = _pricePerType.TryGetValue(vehicleType, out price);

            if (!found)
            {
                throw new NullReferenceException("Type: " + vehicleType.ToString() + "does not have its price registered!");
            }
            return price;
        }

        public void RegisterPricing(VehicleType vehicleType, double price)
        {
            if (_pricePerType.ContainsKey(vehicleType))
            {
                _pricePerType[vehicleType] = price;
            }
            else
            {
                _pricePerType.Add(vehicleType, price);
            }
        }

        public Pricing()
        {
            _pricePerType = new Dictionary<VehicleType, double>();
        }
    }
}
