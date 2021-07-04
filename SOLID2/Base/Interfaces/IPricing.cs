using SOLID2.Base.Vehicles.Interfaces;

namespace SOLID2.Base
{
    public interface IPricing
    {
        /// <summary>
        /// returns -1 when the pricing is not registered
        /// </summary>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        public double GetPricing(IVehicle.VehicleEnum VehicleType);
    }
}
