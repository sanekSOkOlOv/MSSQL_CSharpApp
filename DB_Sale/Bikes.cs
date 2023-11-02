using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Bikes
    {
        public int id { get; set; }
        public string Model { get; set; }
        public int Cost { get; set; }
        public int Speed { get; set; }
        public int Wheel_Size { get; set; }

        public virtual Collection<Rents> Rent { get; set; }

    }
}
