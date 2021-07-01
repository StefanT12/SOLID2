using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Terminal: ITerminal
    {
        public IPricing Pricing { get; set; }
        public List<IZone> Zones { get; set; }
        public List<IEmployee> Employees { get; set; }

        private Result _AssignEmployee(out IEmployee assignedEmployee)
        {
            assignedEmployee = null;

            foreach (var employee in Employees)
            {
                if (employee.IsFree) assignedEmployee = employee;
            }
            //no free employee
            if (assignedEmployee == null)
            {
                return new Result()
                {
                    Code = ResultCode.Fail,
                    CodeMsg = "No free employee"
                };
            }

            //employee is occupied
            assignedEmployee.IsFree = false;
            
            return new Result() { Code = ResultCode.Success };
        }

        public Result ProcessVehicle(IVehicle vehicle)
        {
            //prepare
            var vType = vehicle.GetType(); 
            IEmployee assignedEmployee = null;
            //announce vehicle arrival
            TerminalBacklog.Log("A " + vType + " arrived.");
            //search suitable employee
            var assignResult = _AssignEmployee(out assignedEmployee);
            //here we "free" all employees in case we dont find one free, this is to rotate through all of them for simulation's sake 
            if (assignResult.Code != ResultCode.Success)
            {
                foreach (var employee in Employees)
                {
                    employee.IsFree = true;
                }
                
                assignResult = _AssignEmployee(out assignedEmployee);
                //normally, the terminal should run this code. A solution to this problem may be making a list of pending cars
                //and have a function called CheckPendingCars that would constantly look if there is any free employee?
                //TerminalBacklog.Log("No free employee.");
                //return assignResult;
            }

            TerminalBacklog.Log(assignedEmployee.ID + " will handle the " + vType);

            //run all zones & their operations
            var result = new Result();
            for(int i = 0; i < Zones.Count; i++)
            {
                result = Zones[i].RunOperations(this, assignedEmployee, vehicle);
                //if for some reason it fails, we break the processing
                if (result.Code == ResultCode.Fail)
                {
                    TerminalBacklog.Log(assignedEmployee.ID + " FAILED to process the " + vType + ", CAUSE: " + result.CodeMsg);
                    return result;
                }
                if(result.Code == ResultCode.Embarked)
                {
                    TerminalBacklog.Log(assignedEmployee.ID + " SUCCEEDED to process the " + vType + ".");
                    TerminalBacklog.Log(assignedEmployee.ID + " total income: " + assignedEmployee.Income);
                    //the ferry could be full
                    Zones[i].ProcessFerry();
                    //again, for simulation's sake, we don't free the employee when he finishes but only when there is no new employee to take on a job
                    //employee.IsFree
                    return result;
                }
            }

            TerminalBacklog.Log("The unexpected happened, " + assignedEmployee.ID + ", Code: " + result.Code.ToString() + ", Vehicle: " + vType + ", Code Message: " + result.CodeMsg);
            return result;
        }

    }
}
