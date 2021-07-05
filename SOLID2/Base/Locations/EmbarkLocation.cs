using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class EmbarkLocation : IEmbarkLocation
    {
        private readonly IDockFerryAccess _dock;

        private readonly IVehicle.VehicleEnum _vehicleEnums;

        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            if ((_vehicleEnums & vehicle.VehicleType) != vehicle.VehicleType)
            {
                return Result.NotFit();
            }

            var log = new List<string>();

            log.Add($"[{vehicle.VehicleType}] arrived at [Embark Location] for ferry [{_dock.Ferry.Id}].");

            if (!_dock.Ferry.IsFull)
            {
                log.Add($"[{employee.Id}] found a free parking place for [{vehicle.VehicleType}] on [{_dock.Ferry.Id}].");

                _dock.Ferry.Park(vehicle);

                log.Add($"[{vehicle.VehicleType}] was parked on [{_dock.Ferry.Id}].");

                return Result.Embark(log);
            }

            log.Add("No spaces available on this ferry.");
            return Result.Fail(log);
        }

        public EmbarkLocation(IDockFerryAccess dock, params IVehicle.VehicleEnum[] vehicleTypes)
        {
            _dock = dock;
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                _vehicleEnums |= vehicleTypes[i];
            }
        }
    }
}
