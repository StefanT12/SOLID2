using System;
using System.Collections.Generic;

using System.Linq;

namespace SOLID2.Base
{
    public class Ferry: IFerry
    {
        public string Id { get; private set; }
        private IList<IVehicle> _vehicleSpaces;
        public double Profit { get; private set; }

        public Result FillUpSpace(IVehicle vehicle)
        {
            if (_vehicleSpaces.Count < Size)
            {
                _vehicleSpaces.Add(vehicle);
                return new Result() { Code = ResultCode.Success };
            }
            return Result.Fail ("No Free Space");
        }

        public bool IsFull
        {
            get
            {
                return _vehicleSpaces.Count == Size;
            }
        }

        public int Size { get; private set; }

        public Ferry(string id, int size)
        {
            _vehicleSpaces = new List<IVehicle>(size);
            Size = size;
            Id = id;
        }
    }
}
