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

        public Result RunOperations(ITerminal terminal, IEmployee employee, IVehicle vehicle)
        {
            var res = Result.Fail("No operations");

            for (int i = 0; i < _operations.Count; i++)
            {
                res = _operations[i].Run(Ferry, terminal.Pricing, employee, vehicle);
                
                if(res.IsNotFit)//eliminates empty lines in the console
                {
                    continue;
                }
                
                TerminalBacklog.Log(res.CodeMsg);

                if (res.Code == ResultCode.Fail || res.Code == ResultCode.Embark) 
                {
                    break;
                };
            }

            return res;
        }

        public void ChangeFerry(IFerry newFerry)
        {
            Ferry = newFerry;
        }

        public Zone(string id, IFerry ferry, IEmbarkOperation emabarkOperation, params IRegularOperation [] regularOperations)
        {
            Ferry = ferry;
            _operations = new List<IOperation>(regularOperations.Length+1);
            for(int i=0; i < regularOperations.Length; i++)
            {
                _operations.Add(regularOperations[i]);
            }
            _operations.Add(emabarkOperation);
            ID = id;
        }

    }
}
