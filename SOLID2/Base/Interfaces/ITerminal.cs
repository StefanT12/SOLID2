using System.Collections.Generic;

namespace SOLID2.Base
{
    public interface ITerminal
    {
        public IPricing Pricing { get; }
        public List<IZone> Zones {get;set;}
        public List<IEmployee> Employees { get; set; }
        public Result ProcessVehicle(IVehicle vehicle);
    }
}