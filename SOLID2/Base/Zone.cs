using System;
using System.Collections.Generic;
using SOLID2.Base.Interfaces;

namespace SOLID2.Base
{
    public class Zone : IZone
    {
        private readonly List<IOperation> _operations;
        public IFerry Ferry { get; private set; }
        public string ID { get;}

        //runs the operations until the vehicle either gets embarked or fails at one of them

        public Result RunOperations(ITerminal terminal, IEmployee employee, IVehicle vehicle)
        {
            var res = new Result
            { 
                Code = ResultCode.Fail,
                CodeMsg = "No operations"
            };
            for (int i = 0; i < _operations.Count; i++)
            {
                res = _operations[i].Run(Ferry, terminal.Pricing, employee, vehicle);
                if (res.Code == ResultCode.Fail || res.Code == ResultCode.Embarked) 
                {
                    break;
                };
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
            string rName = Ferry.Id + r.Next(0, 10000).ToString();

            var newFerry = FerryFactory.Create(rName, Ferry);
            Ferry = newFerry;
            
            TerminalBacklog.Log("Ferry in " + ID + " zone is full, this one will go and a new one will arrive.");
        }

        public Zone(string id, IFerry ferry, IEmbarkOperation emabarkOperation, params IRegularOperation [] regularOperations)
        {
            Ferry = ferry;
            _operations = new List<IOperation>(regularOperations.Length+1);
            foreach(var op in regularOperations)
            {
                _operations.Add(op);
            }
            _operations.Add(emabarkOperation);
            ID = id;
        }

    }
}
