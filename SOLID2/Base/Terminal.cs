using System.Collections.Generic;
using System.Linq;

namespace SOLID2.Base
{
    public class Terminal: ITerminal
    {
        public IPricing Pricing { get; set; }
        public IList<IZone> Zones { get; set; }
        public IList<IEmployee> Employees { get; set; }
       
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

            //employee is occupied
            assignedEmployee.IsAvailable = false;

            return assignedEmployee;
        }

        public Result ProcessVehicle(IVehicle vehicle)
        {
            var vType = vehicle.VehicleType.ToString();

            TerminalBacklog.Log($"A {vType} arrived.");

            IEmployee assignedEmployee = _AssignEmployee();

            TerminalBacklog.Log($"{ assignedEmployee.ID} will handle the {vType}");

            var result = new Result();
            for(int i = 0; i < Zones.Count; i++)
            {
                result = Zones[i].RunOperations(this, assignedEmployee, vehicle);
                if (result.Code == ResultCode.Fail)
                {
                    return result;
                }
                if(result.Code == ResultCode.Embark)
                {
                    TerminalBacklog.Log($"{ assignedEmployee.ID} total income: {assignedEmployee.Income}");

                    return result;
                }
            }

            TerminalBacklog.Log($"The unexpected happened, { assignedEmployee.ID }, Code: {result.Code.ToString()} Vehicle: {vType }, Code Message: {result.CodeMsg}");
            return result;
        }

    }
}
