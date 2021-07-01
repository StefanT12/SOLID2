﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public interface IOperation 
    {
        public Result Run(IFerry ferry, IPricing pricing, IEmployee employee, IVehicle vehicle);
    }
}
