using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class VehicleSpace : IVehicleSpace
    {
        public double Price { get; private set; }

        public bool Occupied { get; private set; }

        public IVehicle Vehicle { get; private set; }

        public void Occupy(IVehicle vehicle)
        {
            Vehicle = vehicle;
            Occupied = true;
        }
    }
}
