using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Rents
    {
        public int Rent_id { get; set; }
        public int Сlient_id { get; set; }
        public int bike_id { get; set; }
        public int Day { get; set; }

        public virtual Bikes Bikes { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
