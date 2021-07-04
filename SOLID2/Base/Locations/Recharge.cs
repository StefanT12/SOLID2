using SOLID2.Base.Interfaces;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Locations
{
    public class Recharge : IRegularLocation
    {
        private int GetLevel(IElectricVehicle electricVehicle)
        {
            return (int)(electricVehicle.BatteryLevel * 100);
        }

        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            var vName = vehicle.VehicleType.ToString();

            if (vehicle is IElectricVehicle electricVehicle)
            {
                var log = new List<string>();

                log.Add($"{vehicle.VehicleType} arrived at [Recharge].");

                if (electricVehicle.NeedsRecharge)
                {
                    var oldLevel = GetLevel(electricVehicle);
                    electricVehicle.Recharge();
                    log.Add($"{employee.ID} recharged the {vName} from {oldLevel} % to {GetLevel(electricVehicle)} %.");
                    return Result.Success(log);
                }
                else
                {
                    log.Add($"{vName} had {(int)(electricVehicle.BatteryLevel * 100)} % battery.");
                    return Result.Success(log);
                }
            }

            return Result.NotFit();
        }

    }
}
