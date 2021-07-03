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
                    var price = pricing.GetPricing(vehicle.VehicleType);
                    if(price < 0)
                    {
                        return Result.Fail($"Price for vehicle type {vehicle.VehicleType} was not registered");
                    }
                    employee.Pay(price);
                    return Result.Embark(employee.ID, ferry.Id, vehicle.VehicleType.ToString());
                }
                return res;
            }
            else
            {
                return Result.NotFit();
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
