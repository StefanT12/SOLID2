using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class Refuel : IRegularLocation
    {
        private int GetLevel(IGasVehicle gasVehicle)
        {
            return (int)(gasVehicle.FuelLevel * 100);
        }
        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            var vName = vehicle.VehicleType.ToString();

            if (vehicle is IGasVehicle gasVehicle)
            {
                var log = new List<string>();

                log.Add($"{vehicle.VehicleType} arrived at [Refuel].");

                if (gasVehicle.NeedsRefueling)
                {
                    var oldLevels = GetLevel(gasVehicle);

                    gasVehicle.Refuel();
                    
                    log.Add($"{employee.ID} refuelled the {vName} from {oldLevels} % to {GetLevel(gasVehicle)} %.");

                    return Result.Success(log);
                }
                else
                {
                    log.Add($"{vName} had {(int)(gasVehicle.FuelLevel * 100)} % fuel.");
                    return Result.Success(log);
                }
            }

            return Result.NotFit();
        }
    }
}
