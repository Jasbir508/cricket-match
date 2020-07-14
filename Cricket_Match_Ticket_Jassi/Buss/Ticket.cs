using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cricket_Match_Ticket_Jassi.Buss
{
    public class Ticket
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
