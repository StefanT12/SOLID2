using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public class Embark : FlagBasedLocation, IEmbarkLocation
    {
        private readonly IDockFerryAccess _dock;

        private readonly IPricing _pricing;

        protected override Result InternalLogic(IEmployee employee, IVehicle vehicle)
        {
            var log = new List<string>();

            log.Add($"{vehicle.VehicleType} arrived to [Embark] for ferry {_dock.Ferry.Id}.");

            if (!_dock.Ferry.IsFull)
            {

                log.Add($"Employee {employee.ID} found space for {vehicle.VehicleType} on the ferry.");
                
                var price = _pricing.GetPricing(vehicle.VehicleType);
                
                if (price < 0)
                {
                    log.Add($"Price for vehicle type {vehicle.VehicleType} was not registered.");
                    _dock.Ferry.PurgeLastVehicle();
                    log.Add($"{vehicle.VehicleType} disembarked");
                    return Result.Fail(log);
                }

                employee.Pay(price);
                log.Add($"{vehicle.VehicleType} paid the ticked [{price}USD], employee took {(int)(employee.Cut*100)} % , amouting to [{price * employee.Cut}USD].");
                
                _dock.Ferry.Park(vehicle);
                log.Add($"{vehicle.VehicleType} was embarked on ferry.");

                return Result.Embark(log);
            }

            log.Add("No spaces available on this ferry.");
            return Result.Fail(log);
        }

        public Embark(IPricing pricing, IDockFerryAccess dock, params IVehicle.VehicleEnum[] vehicleType): base(vehicleType)
        {
            _pricing = pricing;
            _dock = dock;
        }
    }
}
