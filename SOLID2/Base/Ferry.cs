using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Ferry: IFerry
    {
        public string ID { get; private set; }
        private List<IVehicleSpace> _vehicleSpaces;
        public double Profit { get; private set; }
        public void RegisterSpace()
        {
            _vehicleSpaces.Add(new VehicleSpace());
        }
        public Result FillUpSpace(IVehicle vehicle)
        {
            foreach(var vs in _vehicleSpaces)
            {
                if (!vs.Occupied)
                {
                    vs.Occupy(vehicle);
                    return new Result() { Code = ResultCode.Success };
                }
            }

            return new Result { Code = ResultCode.Fail, CodeMsg = "No Free Space" };
        }

        public bool IsFull
        {
            get
            {
                for(int i=0; i < _vehicleSpaces.Count; i++)
                {
                    if (!_vehicleSpaces[i].Occupied) return false;
                }
                return true;
            }
        }

        public FerryType FerryType { get; private set; }

        public Ferry(string id, FerryType type)
        {
            _vehicleSpaces = new List<IVehicleSpace>();
            ID = id;
            FerryType = type;
        }
    }
}
