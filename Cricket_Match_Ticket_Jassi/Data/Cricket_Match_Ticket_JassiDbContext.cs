using Cricket_Match_Ticket_Jassi.Buss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cricket_Match_Ticket_Jassi.Data
{
    public class Cricket_Match_Ticket_JassiDbContext:DbContext
    {
        public Cricket_Match_Ticket_JassiDbContext(DbContextOptions<Cricket_Match_Ticket_JassiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
