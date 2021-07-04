using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class CustomsInspect : IRegularLocation
    {
        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            if (vehicle is ICargoVehicle cVehicle)
            {
                var log = new List<string>();

                log.Add($"{vehicle.VehicleType} arrived to [Customs].");

                if (!cVehicle.CargoDoorIsOpen)
                {
                    log.Add($"{vehicle.VehicleType} cargo door was closed.");
                    cVehicle.CargoDoorIsOpen = true;
                    log.Add($"Opening {vehicle.VehicleType} cargo door.");
                }
                else
                {
                    log.Add($"{vehicle.VehicleType} door was open.");
                }

                log.Add($"Inspecting {vehicle.VehicleType} cargo.");
                
                //inspection??
                //{
                //
                //}

                log.Add($"The {vehicle.VehicleType} passed customs.");


                cVehicle.CargoDoorIsOpen = false;

                log.Add($"Closing {vehicle.VehicleType} cargo doors.");

                cVehicle.CargoDoorIsOpen = false;
                return Result.Success(log);
            }

            return Result.NotFit();
        }
    }
}
