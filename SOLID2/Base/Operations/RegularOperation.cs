using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Operations
{
    public abstract class Operation : IOperation
    {
        private readonly IVehicle.VehicleEnum VehicleEnums;

        public Result Run(IEmployee employee, IVehicle vehicle)
        {
            
            if ((VehicleEnums & vehicle.VehicleType) == vehicle.VehicleType)
            {
                return InternalLogic(employee, vehicle);
            }
            return Result.NotFit();
        }

        protected abstract Result  InternalLogic(IEmployee employee, IVehicle vehicle);

        public Operation(params IVehicle.VehicleEnum[] vehicleType)
        {
            for (int i = 0; i < vehicleType.Length; i++)
            {
                VehicleEnums |= vehicleType[i];
            }
        }
    }
}
