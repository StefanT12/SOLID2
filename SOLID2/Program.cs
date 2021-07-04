using SOLID2.Base;
using SOLID2.Base.Interfaces;
using SOLID2.Base.Locations;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID2
{
    class Program
    {
        private const ConsoleKey _stopTerminalKey = ConsoleKey.E;
        private const ConsoleKey _processVehicleKey = ConsoleKey.Q;
        private static ITerminal _terminal;
        private static IList<Dock> _docks;

        private static void _PrintInstructions()
        {
            Console.Write("\n");
            Console.Write($"\nPress '{_stopTerminalKey}' to shut down Ferry Terminal App...");
            Console.Write($"\nPress '{_processVehicleKey}' to simulate the proccessing of a random vehicle...");
        }

        static void Main(string[] args)
        {
            _docks = new List<Dock>()
            {
                new Dock(FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{FerryFactory.FerryType.Small}", FerryFactory.FerryType.Small)),
                new Dock(FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{FerryFactory.FerryType.Large}", FerryFactory.FerryType.Large)),
                new Dock(FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{FerryFactory.FerryType.Eco}", FerryFactory.FerryType.Eco))
            };

            #region terminal creation
            _terminal = new Terminal
                (
                    new List<IEmbarkLocation>()
                    {
                        new EmbarkLocation(_docks[0], IVehicle.VehicleEnum.Car, IVehicle.VehicleEnum.Van),
                        new EmbarkLocation(_docks[1], IVehicle.VehicleEnum.Bus, IVehicle.VehicleEnum.Truck),
                        new EmbarkLocation(_docks[2], IVehicle.VehicleEnum.Electric, IVehicle.VehicleEnum.Hybrid)
                    },
                    new List<IRegularLocation>()
                    {
                        new ArrivalLocation
                        (
                            new Pricing
                            (
                                new Dictionary<IVehicle.VehicleEnum, double>
                                {
                                    {IVehicle.VehicleEnum.Car, 3},
                                    {IVehicle.VehicleEnum.Van, 4},
                                    {IVehicle.VehicleEnum.Bus, 5},
                                    {IVehicle.VehicleEnum.Truck, 6},
                                    {IVehicle.VehicleEnum.Electric, 1},
                                    {IVehicle.VehicleEnum.Hybrid, 2}
                                }
                            )
                        ),
                        new GasStation(),
                        new CustomsLocation(),
                        new RechargeStation()
                    },
                    new List<IEmployee>()
                    {
                        new Employee("jim",0.1),
                        new Employee("chimichanga",0.1),
                        new Employee("perdo",0.11)
                    }
                );
            #endregion

            #region tests
            //    Tests.TestHybridProcessing(_terminal,0.6,0.6);
            //    return;
            #endregion

            #region main loop
            Console.Write("\nFerry Terminal App Initialized...");

            _PrintInstructions();

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == _processVehicleKey)
                {
                    Console.Write("\n");
                    var log = _terminal.ProcessVehicle(VehicleFactory.RandomVehicle());
                    for (int i = 0; i < log.Count; i++)
                    {
                        Console.Write($"\n{log[i]}");
                    }

                    var simMsg = FerryTrafficSimulation.RunSimulation(_docks);
                    Console.Write("\n........");
                    Console.Write($"\n{simMsg}");

                    _PrintInstructions();
                }
                if (key == _stopTerminalKey)
                {
                    Console.Write("\n");
                    break;
                }
            }

            #endregion
        }
    }
}
