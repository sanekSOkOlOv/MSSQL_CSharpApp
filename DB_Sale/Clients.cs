using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Clients
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Sale_Id { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
