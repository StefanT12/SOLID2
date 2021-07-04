using SOLID2.Base.Interfaces;
using SOLID2.Base.Vehicles;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public static class Tests
    {
        private static void _Print(IList<string> log)
        {
            for (int i = 0; i < log.Count; i++)
            {
                Console.Write($"\n{log[i]}");
            }
        }

        public static void TestHybridProcessing(ITerminal terminal, double fuel, double battery)
        {
            var log = terminal.ProcessVehicle(new HybridVehicle(fuel, 0.5, battery, 0.5, IVehicle.VehicleEnum.Hybrid));
            _Print(log);
        }

        public static void TestCargoProcessing(ITerminal terminal, double fuel, bool cargoDoorIsOpen)
        {
            var log = terminal.ProcessVehicle(new CargoVehicle(fuel, IVehicle.VehicleEnum.Truck, 0.1, cargoDoorIsOpen));
            _Print(log);
        }
    }
}
