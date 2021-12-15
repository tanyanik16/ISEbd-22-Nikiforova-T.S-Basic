using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTANK
{
      class ParkingOccupiedPlaceException : Exception
        {
            public ParkingOccupiedPlaceException() : base("Не удалось припарковать")
            { }
       }
    
}
