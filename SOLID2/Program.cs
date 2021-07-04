using SOLID2.Base;
using SOLID2.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID2
{
    class Program
    {
        private const ConsoleKey _stopTerminalKey = ConsoleKey.E;
        private const ConsoleKey _processVehicleKey = ConsoleKey.Q;
        private static ITerminal _terminal;
        private static IList<Dock> _docs;
        static void Main(string[] args)
        {
            //create terminal
            {
                IPricing pricing = new Pricing(new Dictionary<IVehicle.VehicleEnum, double> {
                    {IVehicle.VehicleEnum.Car, 3},
                    {IVehicle.VehicleEnum.Van, 4},
                    {IVehicle.VehicleEnum.Bus, 5},
                    {IVehicle.VehicleEnum.Truck, 6}
                });

                _docs = new List<Dock>();
                _docs.Add(new Dock(FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{FerryFactory.FerryType.Small}", FerryFactory.FerryType.Small)));
                _docs.Add(new Dock(FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{FerryFactory.FerryType.Large}", FerryFactory.FerryType.Large)));

                _terminal = new Terminal
                    (
                        new List<IEmbarkOperation>()
                        {
                        new Embark(pricing, _docs[0], IVehicle.VehicleEnum.Car, IVehicle.VehicleEnum.Van),
                        new Embark(pricing, _docs[1], IVehicle.VehicleEnum.Bus, IVehicle.VehicleEnum.Truck)
                        },
                        new List<IRegularOperation>()
                        {
                        new RefuelVehicle(IVehicle.VehicleEnum.Car, IVehicle.VehicleEnum.Van, IVehicle.VehicleEnum.Bus, IVehicle.VehicleEnum.Truck),
                        new CustomsInspect(IVehicle.VehicleEnum.Van, IVehicle.VehicleEnum.Truck)
                        },
                        new List<IEmployee>()
                        {
                        new Employee("jim",0.1),
                        new Employee("chimichanga",0.1),
                        new Employee("perdo",0.11)
                        }
                    );
            }
            
            Console.Write("\nFerry Terminal App Initiated...");
            Console.Write($"\nPress '{_stopTerminalKey}' to shut down Ferry Terminal App...");
            Console.Write($"\nPress '{_processVehicleKey}' to proccess a vehicle...");

            {
                //var test = new Tests();
                //test.TestCarProcessing(_terminal);
                //return;
            }

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == _processVehicleKey)
                {
                    Console.Write("\n");
                    var log = _terminal.ProcessVehicle(VehicleFactory.RandomVehicle());
                    for(int i = 0; i < log.Count; i++)
                    {
                        Console.Write($"\n{log[i]}");
                    }

                    var simMsg = FerryTrafficSimulation.RunSimulation(_docs);

                    Console.Write($"\n{simMsg}");
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
