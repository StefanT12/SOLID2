using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public interface IFuel
    {
        public double Level { get; }
        public void Refuel();
    }

    public class Gas : IFuel
    {
        public double Level { get; private set; }

        public void Refuel()
        {
            Level = 1;
        }

        public Gas(double level)
        {
            Level = level;
        }
    }

    public interface IVehicle
    {
        public string GetType();
        public VehicleType VehicleType { get; }
        public IFuel Fuel { get; }
    }

    public class Vehicle: IVehicle
    {
        /// <summary>
        /// gets vehicle type as string
        /// </summary>
        /// <returns></returns>
        public new string GetType() { return VehicleType.ToString(); } 
        public VehicleType VehicleType { get; set; }
        public IFuel Fuel { get; set; }

        public Vehicle()
        {

        }
    }
}
