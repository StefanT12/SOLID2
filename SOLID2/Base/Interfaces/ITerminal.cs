using System.Collections.Generic;

namespace SOLID2.Base
{
    public interface ITerminal
    {
        public IPricing Pricing { get; }
        public IList<IZone> Zones {get;}
        public IList<IEmployee> Employees { get;}
        public Result ProcessVehicle(IVehicle vehicle);
    }
}