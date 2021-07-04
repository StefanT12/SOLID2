using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Tests
    {
        private void _Print(IList<string> log)
        {
            for (int i = 0; i < log.Count; i++)
            {
                Console.Write($"\n{log[i]}");
            }
        }
        public void TestCarProcessing(ITerminal terminal)
        {
            var log = terminal.ProcessVehicle(new Vehicle() { Fuel = new Gas(0.09), VehicleType = IVehicle.VehicleEnum.Car });
            _Print(log);
        }
    }
}
