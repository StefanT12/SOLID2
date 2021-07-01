using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Zone : IZone
    {
        private List<IOperation> _operations;
        public IFerry Ferry { get; set; }
        public string ID { get; private set; }

        public void AddOperations(params IOperation[] operations)
        {
            if(operations.Length < 2)
            {
                _operations.Add(_operations[0]);
                return;
            }
            for(int i=0; i< operations.Length; i++)
            {
                _operations.Add(operations[i]);
            }
        }
        //runs the operations until the vehicle either gets embarked or fails at one of them

        public Result RunOperations(ITerminal terminal, IEmployee employee, IVehicle vehicle)
        {
            Result res = new Result();
            for (int i = 0; i < _operations.Count; i++)
            {
                res = _operations[i].Run(Ferry, terminal.Pricing, employee, vehicle);
                if (res.Code == ResultCode.Fail || res.Code == ResultCode.Embarked) break;
            }
            return res;
        }

        /// <summary>
        /// When the ferry is full, the zone approves its leave and calls in for another, empty ferry
        /// </summary>
        public void ProcessFerry()
        {
            if (!Ferry.IsFull) return;

            //we generate a "random" name
            Random r = new Random();
            string rName = Ferry.ID + r.Next(0, 10000).ToString();

            var newFerry = FerryFactory.Create(rName, Ferry.FerryType);
            Ferry = newFerry;
            
            TerminalBacklog.Log("Ferry in " + ID + " zone is full, this one will go and a new one will arrive.");
        }

        public Zone(string id)
        {
            _operations = new List<IOperation>();
            ID = id;
        }

    }
}
