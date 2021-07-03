using SOLID2.Base.Interfaces;


namespace SOLID2.Base
{
    public class RefuelVehicle : IRegularOperation
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            var vName = vehicle.VehicleType.ToString();
            var vFLevel = (int)(vehicle.Fuel.Level * 100);//convert in percent
    
            if (vFLevel < 10)
            {
                vehicle.Fuel.Refuel();
                var msg = employee.ID + " refuelled the " + vName + " from " + vFLevel + "% to"+ (int)(vehicle.Fuel.Level * 100)+"%";
                TerminalBacklog.Log(msg);
                return new Result { Code = ResultCode.Success, CodeMsg = msg };
            }
            return new Result { Code = ResultCode.Success, CodeMsg = vName + " had " + vFLevel + "% fuel." };
        }
    }
}
