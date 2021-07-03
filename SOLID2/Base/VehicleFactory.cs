namespace SOLID2.Base
{
    public static class VehicleFactory
    {
        public static IVehicle GasCar(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel),
                VehicleType= IVehicle.VehicleEnum.Car 
            };
        }

        public static IVehicle Truck(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel), 
                VehicleType = IVehicle.VehicleEnum.Truck 
            };
        }

        public static IVehicle Bus(double gasLevel)
        {
            return new Vehicle() 
            { 
                Fuel = new Gas(gasLevel), 
                VehicleType = IVehicle.VehicleEnum.Bus 
            };
        }
    }
}
