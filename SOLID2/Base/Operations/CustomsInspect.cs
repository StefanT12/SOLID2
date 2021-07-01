using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class CustomsInspect : IOperation
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            TerminalBacklog.Log("The " + vehicle.GetType() + " passed customs.");
            return new Result { Code = ResultCode.Success };
        }
    }
}
