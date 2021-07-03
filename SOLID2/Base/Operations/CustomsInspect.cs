using SOLID2.Base.Interfaces;

namespace SOLID2.Base
{
    public class CustomsInspect : IRegularOperation
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            return Result.Success($"The {vehicle.VehicleType} passed customs.");
        }
    }
}
