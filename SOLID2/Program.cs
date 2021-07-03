using SOLID2.Base;
using System;
using System.Collections.Generic;

namespace SOLID2
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal
            {
                Pricing = new Pricing(new Dictionary<IVehicle.VehicleEnum, double> {
                    {IVehicle.VehicleEnum.Car, 3},
                    {IVehicle.VehicleEnum.Van, 4},
                    {IVehicle.VehicleEnum.Bus, 5},
                    {IVehicle.VehicleEnum.Truck, 6}
                }),
                Zones = new List<IZone>()
                {
                    new Zone("crossroads1", FerryFactory.Create("eutisania_small", FerryFactory.FerryType.Small), new Embark(IVehicle.VehicleEnum.Car, IVehicle.VehicleEnum.Van), new RefuelVehicle()),
                    new Zone("crossroads2", FerryFactory.Create("eutisania_big", FerryFactory.FerryType.Large), new Embark(IVehicle.VehicleEnum.Bus, IVehicle.VehicleEnum.Truck), new CustomsInspect())
                },
                Employees = new List<IEmployee>()
                {
                    new Employee("jim",0.1),
                    new Employee("chimichanga",0.1),
                    new Employee("perdo",0.11)
                }
            };

            terminal.ProcessVehicle(VehicleFactory.GasCar(0.2));
            terminal.ProcessVehicle(VehicleFactory.Truck(0.05));
            terminal.ProcessVehicle(VehicleFactory.Bus(0.33));
            terminal.ProcessVehicle(VehicleFactory.GasCar(0.01));
        }
    }
}
