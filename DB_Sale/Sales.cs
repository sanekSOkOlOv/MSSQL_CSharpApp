using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Sales
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Percent_Sale { get; set; }

        public virtual ICollection<Clients> Clients { get; set; }

    }
}
