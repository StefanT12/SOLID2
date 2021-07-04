using SOLID2.Base.Interfaces;
using SOLID2.Base.Operations;

namespace SOLID2.Base
{
    public class Embark : Operation, IEmbarkOperation
    {
        private readonly IDockFerryAccess _dock;

        private readonly IPricing _pricing;

        protected override Result InternalLogic(IEmployee employee, IVehicle vehicle)
        {
            var res = _dock.Ferry.FillUpSpace(vehicle);
            if (res.Code != ResultCode.Fail)
            {
                var price = _pricing.GetPricing(vehicle.VehicleType);
                if (price < 0)
                {
                    return Result.Fail($"Price for vehicle type {vehicle.VehicleType} was not registered");
                }
                employee.Pay(price);
                return Result.Embark(employee.ID, _dock.Ferry.Id, vehicle.VehicleType.ToString());
            }
            return res;
        }

        public Embark(IPricing pricing, IDockFerryAccess dock, params IVehicle.VehicleEnum[] vehicleType): base(vehicleType)
        {
            _pricing = pricing;
            _dock = dock;
        }
    }
}
