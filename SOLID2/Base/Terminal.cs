using SOLID2.Base.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SOLID2.Base
{
    public class Terminal: ITerminal
    {
        public IList<IEmployee> Employees { get; }

        private readonly IList<IOperation> _operations;
        private IEmployee _AssignEmployee()
        {
            var assignedEmployee = Employees.FirstOrDefault(x=>x.IsAvailable);
            
            if (assignedEmployee == null)
            {
                foreach (var employee in Employees)
                {
                    employee.IsAvailable = true;
                }

                assignedEmployee = Employees[0];
            }

            assignedEmployee.IsAvailable = false;

            return assignedEmployee;
        }

        public IList<string> ProcessVehicle(IVehicle vehicle)
        {
            var log = new List<string>();

            var vType = vehicle.VehicleType.ToString();

            log.Add($"A {vType} arrived.");

            IEmployee assignedEmployee = _AssignEmployee();

            log.Add($"{ assignedEmployee.ID} will handle the {vType}");

            for(int i = 0; i < _operations.Count; i++)
            {
                var result = _operations[i].Run(assignedEmployee, vehicle);
                
                if (!result.IsNotFit)
                {
                    log.Add(result.CodeMsg);
                }
                
                if (result.Failed )
                {
                    break;
                }

                if (result.Embarked)
                {
                    log.Add($"{ assignedEmployee.ID} total income: {assignedEmployee.Income}");
                    break;
                }
            }
            return log;
        }

        public Terminal(IList<IEmbarkOperation> embarkOperations, IList<IRegularOperation> regularOperations, IList<IEmployee> employees)
        {
            Employees = employees;

            var totalCount = regularOperations.Count + embarkOperations.Count;

            _operations = new List<IOperation>(totalCount);

            for (int i = 0; i < totalCount; i++)
            {
                if(i < regularOperations.Count)
                {
                    _operations.Add(regularOperations[i]);
                }
                else
                {
                    _operations.Add(embarkOperations[i - regularOperations.Count]);
                }
            }
        }

    }
}
