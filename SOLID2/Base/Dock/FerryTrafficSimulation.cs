using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public static class FerryTrafficSimulation
    {
        public static string RunSimulation(IList<Dock> docks)
        {
            foreach(var dock in docks)
            {
                if (dock.Ferry.IsFull)
                {
                    var newferryType = (FerryFactory.FerryType)dock.Ferry.Size;
                    var newFerry = FerryFactory.Create($"{FerryRandNameGen.CreateRandomName()}_{newferryType}", newferryType);
                    
                    var res = dock.ChangeFerry(newFerry);

                    return $"SIMULATION: {res}.";
                }
            }

            return "SIMULATION: Ferries are still anchored near the docks.";
        }
    }
}
