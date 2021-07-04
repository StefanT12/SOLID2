using SOLID2.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public class Dock: IDockFerryAccess
    {
        public IFerry Ferry { get; private set; }
        public string ChangeFerry(IFerry newFerry)
        {
            
            var msg = $"Ferry [{Ferry.Id}] left the docking area, Ferry [{newFerry.Id}] entered the docking area";
            Ferry = newFerry;
            return msg;
        }

        public Dock(IFerry ferry)
        {
            Ferry = ferry;
        }
    }
}
