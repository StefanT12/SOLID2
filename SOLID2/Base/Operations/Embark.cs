using SOLID2.Base.Interfaces;

namespace SOLID2.Base
{
    public class Embark : IEmbarkOperation
    {
        private readonly IVehicle.VehicleEnum VehicleEnums;
       
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle)
        {
            
            if ((VehicleEnums & vehicle.VehicleType) == vehicle.VehicleType)
            {
                //we need to check for available spaces
                var res = ferry.FillUpSpace(vehicle);
                if(res.Code != ResultCode.Fail)
                {
                    employee.Pay(pricing.GetPricing(vehicle.VehicleType));
                    TerminalBacklog.Log(employee.ID + " parked the " + vehicle.VehicleType.ToString() + " on ferry " + ferry.Id);
                    return new Result { Code = ResultCode.Embarked };
                }
                TerminalBacklog.Log(employee.ID + " had no space to park the " + vehicle.VehicleType.ToString());
                return res;
            }
            else//not for this ferry
            {
                return new Result { Code = ResultCode.NotFit };
            }
        }

        public Embark(params IVehicle.VehicleEnum[] vehicleType)
        {
            //append to flag
            for (int i=0; i< vehicleType.Length; i++)
            {
                VehicleEnums |= vehicleType[i];
            }
        }
    }
}
