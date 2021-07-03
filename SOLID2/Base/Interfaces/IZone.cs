namespace SOLID2.Base
{
    public interface IZone
    {
        public string ID { get; }
        public IFerry Ferry { get; }
        /// <summary>
        /// adds operations that can be performed by the employees in said zone
        /// </summary>
        /// <param name="operations">must be added in order</param>
        public Result RunOperations(ITerminal terminal, IEmployee employee, IVehicle vehicle);

        public void ChangeFerry(IFerry newFerry);
    }
}