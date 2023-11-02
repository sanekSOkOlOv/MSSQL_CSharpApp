using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Rents
    {
        public int id { get; set; }
        public int id_client { get; set; }
        public int id_bike { get; set; }
        public int day { get; set; }

        public virtual Bikes Bikes { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
