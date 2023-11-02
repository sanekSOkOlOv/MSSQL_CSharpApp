using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Sale
{
    public class Rents
    {
        [Key]
        public int Rent_id { get; set; }
        
        public int Client_id { get; set; }
        
        public int Bike_id { get; set; }
        public int Day { get; set; }

        [ForeignKey("Client_id")] 
        public virtual Clients Clients { get; set; }

        [ForeignKey("Bike_id")] 
        public virtual Bikes Bikes { get; set; }


    }
}
