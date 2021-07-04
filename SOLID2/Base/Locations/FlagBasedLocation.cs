using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base.Locations
{
    public abstract class FlagBasedLocation : ILocation
    {
        private readonly IVehicle.VehicleEnum _vehicleEnums;

        public Result RunOperations(IEmployee employee, IVehicle vehicle)
        {
            
            if ((_vehicleEnums & vehicle.VehicleType) == vehicle.VehicleType)
            {
                return InternalLogic(employee, vehicle);
            }
            return Result.NotFit();
        }

        protected abstract Result  InternalLogic(IEmployee employee, IVehicle vehicle);

        public FlagBasedLocation(params IVehicle.VehicleEnum[] vehicleType)
        {
            for (int i = 0; i < vehicleType.Length; i++)
            {
                _vehicleEnums |= vehicleType[i];
            }
        }
    }
}
