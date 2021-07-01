using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class TankVehicle : IOperation
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            var vName = vehicle.GetType();
            var vFLevel = (int)(vehicle.Fuel.Level * 100);//convert in percent
            var msg = vName + " had " + vFLevel + "% fuel.";//presume we have the fuel

            if (vFLevel < 10)
            {
                vehicle.Fuel.Refuel();
                msg = employee.ID + " refuelled the " + vName + " from " + vFLevel + "% to 100%";
                TerminalBacklog.Log(msg);
                return new Result { Code = ResultCode.Success, CodeMsg = msg };
            }
            return new Result { Code = ResultCode.Success, CodeMsg = msg };
        }
    }
}
