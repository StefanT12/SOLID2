using SOLID2.Base.Interfaces;
using SOLID2.Base.Vehicles.Interfaces;

namespace SOLID2.Base
{
    public class CargoVehicle : GasVehicle, ICargoVehicle
    {
        public bool CargoDoorIsOpen { get ; set ; }

        public CargoVehicle(double fuel, IVehicle.VehicleEnum vehicleType, double refuelLevel, bool cargoDoorIsOpen):base(fuel, vehicleType, refuelLevel)
        {
            CargoDoorIsOpen = cargoDoorIsOpen;
        }
    }
}
