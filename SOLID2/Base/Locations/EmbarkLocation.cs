using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class EmbarkLocation : FlagBasedLocation, IEmbarkLocation
    {
        private readonly IDockFerryAccess _dock;

        protected override Result InternalLogic(IEmployee employee, IVehicle vehicle)
        {
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

        public EmbarkLocation(IDockFerryAccess dock, params IVehicle.VehicleEnum[] vehicleType): base(vehicleType)
        {
            _dock = dock;
        }
    }
}
