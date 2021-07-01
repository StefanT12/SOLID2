using SOLID2.Base;
using System;
using System.Collections.Generic;

namespace SOLID2
{
    class Program
    {
        static void Main(string[] args)
        {
            //----create ferries
            IFerry smallFerry = FerryFactory.Create("eutisania_small", FerryType.Small);
            IFerry largeFerry = FerryFactory.Create("eutisania_big", FerryType.Large);
            //----create pricing
            IPricing pricing = new Pricing();

            pricing.RegisterPricing(VehicleType.Car, 3);
            pricing.RegisterPricing(VehicleType.Van, 4);
            pricing.RegisterPricing(VehicleType.Bus, 5);
            pricing.RegisterPricing(VehicleType.Truck, 6);

            //----create employees
            IEmployee employee1 = new Employee(id: "jim") 
            { 
                Cut = 0.1, 
            };
            IEmployee employee2 = new Employee(id: "chimichanga")
            {
                Cut = 0.1, 
            };
            IEmployee employee3 = new Employee(id: "perdo")
            {
                Cut = 0.11, 
            };
            List<IEmployee> employees = new List<IEmployee>() { employee1, employee2, employee3 };

            //----create zones
            
            //--crossroads1
            //crossroads1 operations
            IOperation tankVehicle = new TankVehicle();
            IOperation embarkSmallFerry = new Embark(VehicleType.Car, VehicleType.Van);
            
            //create crossroads1
            IZone crossroads1 = new Zone("crossroads1") { Ferry = smallFerry };
            crossroads1.AddOperations(tankVehicle, embarkSmallFerry);
            
            //--crossroads2
            //crossroads2 operations
            IOperation customs = new CustomsInspect();
            IOperation embarkLargeFerry = new Embark(VehicleType.Bus, VehicleType.Truck);
            
            //create crossroads2
            IZone crossroads2 = new Zone("crossroads2") { Ferry = largeFerry };
            crossroads2.AddOperations(customs, embarkLargeFerry);

            //--zones in order
            List<IZone> zones = new List<IZone>() { crossroads1, crossroads2 };

            //----terminal
            Terminal terminal = new Terminal
            {
                Pricing = pricing,
                Zones = zones,
                Employees = employees
            };

            //test
            IVehicle v = VehicleFactory.GasCar(0.2);
            IVehicle v2 = VehicleFactory.Truck(0.05);
            IVehicle v3 = VehicleFactory.Bus(0.33);
            IVehicle v4 = VehicleFactory.GasCar(0.01);

            terminal.ProcessVehicle(v);
            terminal.ProcessVehicle(v2);
            terminal.ProcessVehicle(v3);
            terminal.ProcessVehicle(v4);

        }
    }
}
