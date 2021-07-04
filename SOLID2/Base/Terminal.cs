using SOLID2.Base.Interfaces;
using SOLID2.Base.Vehicles.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SOLID2.Base
{
    public class Terminal: ITerminal
    {
        public IList<IEmployee> Employees { get; }

        private readonly IList<ILocation> _locations;
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

            for(int i = 0; i < _locations.Count; i++)
            {
                var result = _locations[i].RunOperations(assignedEmployee, vehicle);
                
                if (!result.IsNotFit)
                {
                    log.AddRange(result.Log);
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

        public Terminal(IList<IEmbarkLocation> embarkLocations, IList<IRegularLocation> regularLocations, IList<IEmployee> employees)
        {
            Employees = employees;

            var totalCount = regularLocations.Count + embarkLocations.Count;

            _locations = new List<ILocation>(totalCount);

            for (int i = 0; i < totalCount; i++)
            {
                if(i < regularLocations.Count)
                {
                    _locations.Add(regularLocations[i]);
                }
                else
                {
                    _locations.Add(embarkLocations[i - regularLocations.Count]);
                }
            }
        }

    }
}
