using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    class Employee : IEmployee
    {
        public string ID { get; private set; }

        public double Income { get; private set; }

        public double Cut { get; set; }

        public bool IsFree { get; set; }

        public void Pay(double amount)
        {
            Income += Cut * amount;
        }

        public Employee(string id)
        {
            ID = id;
            IsFree = true;
        }
    }
}
