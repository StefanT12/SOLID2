using SOLID2.Base.Interfaces;
using SOLID2.Base.Operations;

namespace SOLID2.Base
{
    public class CustomsInspect : Operation, IRegularOperation
    {
        protected override Result InternalLogic(IEmployee employee, IVehicle vehicle)
        {
            return Result.Success($"The {vehicle.VehicleType} passed customs.");
        }

        public CustomsInspect(params IVehicle.VehicleEnum[] vehicleType) : base(vehicleType)
        {
            
        }
    }
}
