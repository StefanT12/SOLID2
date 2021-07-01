using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Embark : IOperation
    {
        public VehicleType VehicleTypes { get; private set; }
       
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            
            if (VehicleTypes.HasFlag(vehicle.VehicleType))
            {
                //we need to check for available spaces
                var res = ferry.FillUpSpace(vehicle);
                if(res.Code != ResultCode.Fail)
                {
                    employee.Pay(pricing.GetPricing(vehicle.VehicleType));
                    TerminalBacklog.Log(employee.ID + " parked the " + vehicle.GetType() + " on ferry " + ferry.ID);
                    return new Result { Code = ResultCode.Embarked };
                }
                TerminalBacklog.Log(employee.ID + " had no space to park the " + vehicle.GetType());
                return res;
            }
            else//not for this ferry
            {
                return new Result { Code = ResultCode.NotFit };
            }
        }

        public Embark(params VehicleType[] vehicleTypes)
        {
            //append to flag
            for (int i=0; i< vehicleTypes.Length; i++)
            {
                VehicleTypes |= vehicleTypes[i];
            }
        }
    }
}
