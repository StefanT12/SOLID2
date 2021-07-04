namespace SOLID2.Base
{
    public interface IEmployee 
    {
        public string Id { get; }
        public double Income { get; }
        public double Cut { get; }
        public bool IsAvailable { get; set; }
        public void Pay(double fromAmount);

    }
}