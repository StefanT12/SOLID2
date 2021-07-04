using SOLID2.Base.Interfaces;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Locations
{
    public class ArrivalLocation : IRegularLocation
    {
        private IPricing _pricing;
        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            var price = _pricing.GetPricing(vehicle.VehicleType);

            var log = new List<string>();

            log.Add($"[{vehicle.VehicleType}] awaits at [Arrival] for [{employee.Id}].");

            if (price < 0)
            {
                log.Add($"Price for vehicle type [{vehicle.VehicleType}] was not registered");

                return Result.Fail(log);
            }

            employee.Pay(price);
           
            log.Add($"[{vehicle.VehicleType}] paid the ticked {price} USD, [{employee.Id}] took {(int)(employee.Cut * 100)} % , amounting to {Math.Round(price * employee.Cut, 4)} USD.");
            
            log.Add($"[{employee.Id}] total income: {Math.Round(employee.Income, 4)} USD.");
            
            return Result.Success(log);
        }

        public ArrivalLocation(IPricing pricing)
        {
            _pricing = pricing;
        }
    }
}
