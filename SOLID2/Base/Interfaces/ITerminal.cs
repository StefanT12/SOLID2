using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;

namespace SOLID2.Base
{
    public interface ITerminal
    {
        public IList<IEmployee> Employees { get; }

        public IList<string> ProcessVehicle(IVehicle vehicle);
    }
}