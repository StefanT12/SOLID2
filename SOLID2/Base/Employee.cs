using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    class Employee : IEmployee
    {
        public string ID { get; private set; }

        public double Income { get; private set; }

        public double Cut { get;}

        public bool IsAvailable { get; set; } = true;

        public void Pay(double amount)
        {
            Income += Cut * amount;
        }

        public Employee(string id, double cut)
        {
            ID = id;
            Cut = cut;
        }
    }
}
