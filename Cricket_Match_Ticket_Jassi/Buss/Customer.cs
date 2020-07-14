using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cricket_Match_Ticket_Jassi.Buss
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public int TicketID { get; set; }
        public int SeatID { get; set; }

        public virtual Seat Seat { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
