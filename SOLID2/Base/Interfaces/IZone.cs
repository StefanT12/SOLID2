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
        /// <summary>
        /// check if ferry is full, call a new one in that case
        /// </summary>
        public void ProcessFerry();
    }
}