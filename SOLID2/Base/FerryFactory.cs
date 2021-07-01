using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public static class FerryFactory
    {
        public static IFerry Create(string id, FerryType type)
        {
            IFerry ferry = new Ferry(id, type);
            int spacesNR = 0;
            switch (type)
            {
                case FerryType.Large:
                    spacesNR = 8;
                    break;
                case FerryType.Small:
                    spacesNR = 6;
                    break;
                default:
                    spacesNR = 5;
                    break;
            }

            for(int i = 0; i < spacesNR; i++)
            {
                ferry.RegisterSpace();
            }
            return ferry;
        }

    }
}
