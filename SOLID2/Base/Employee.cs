using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Employee : IEmployee
    {
        public string Id { get; private set; }

        public double Income { get; private set; }

        public double Cut { get;}

        public bool IsAvailable { get; set; } = true;

        public void Pay(double amount)
        {
            Income += Cut * amount;
        }

        public Employee(string id, double cut)
        {
            Id = id;
            Cut = cut;
        }
    }
}
