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
                return Result.Success ($"{employee.ID} refuelled the {vName} from {vFLevel} % to {(int)(vehicle.Fuel.Level * 100)} %");
            }
            return Result.Success( $"{vName} had {vFLevel} % fuel.");
        }
    }
}
