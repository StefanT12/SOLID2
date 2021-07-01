using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public enum FerryType
    {
        Large,
        Small
    }
    public interface IFerry
    {
        public string ID { get; }
        public FerryType FerryType { get; }
        public void RegisterSpace();
        public Result FillUpSpace(IVehicle vehicle);
        public bool IsFull { get; }
    }
}
