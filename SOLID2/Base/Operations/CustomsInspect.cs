using SOLID2.Base.Interfaces;

namespace SOLID2.Base
{
    public class CustomsInspect : IRegularOperation
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            TerminalBacklog.Log("The " + vehicle.VehicleType.ToString() + " passed customs.");
            return new Result { Code = ResultCode.Success };
        }
    }
}
