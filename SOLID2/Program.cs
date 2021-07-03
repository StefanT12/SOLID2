using SOLID2.Base;
using System;
using System.Collections.Generic;

namespace SOLID2
{
    class Program
    {
        private static readonly ConsoleKey _stopTerminalKey = ConsoleKey.E;
        private static readonly ConsoleKey _processVehicleKey= ConsoleKey.Q;
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
                    new Zone("crossroads1", FerryFactory.CreateRandom(FerryFactory.FerryType.Small), new Embark(IVehicle.VehicleEnum.Car, IVehicle.VehicleEnum.Van), new RefuelVehicle()),
                    new Zone("crossroads2", FerryFactory.CreateRandom(FerryFactory.FerryType.Large), new Embark(IVehicle.VehicleEnum.Bus, IVehicle.VehicleEnum.Truck), new CustomsInspect())
                },
                Employees = new List<IEmployee>()
                {
                    new Employee("jim",0.1),
                    new Employee("chimichanga",0.1),
                    new Employee("perdo",0.11)
                }
            };

            Console.Write("\nFerry Terminal App Initiated...");
            Console.Write($"\nPress '{_stopTerminalKey}' to shut down Ferry Terminal App...");
            Console.Write($"\nPress '{_processVehicleKey}' to proccess a vehicle...");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == _processVehicleKey)
                {
                   Console.Write("\n");
                   terminal.ProcessVehicle(VehicleFactory.RandomVehicle());
                }
                if (key == _stopTerminalKey)
                {
                    Console.Write("\n");
                    break;
                }
            }
        }
    }
}
