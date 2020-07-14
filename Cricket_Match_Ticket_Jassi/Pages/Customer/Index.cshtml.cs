using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cricket_Match_Ticket_Jassi.Buss;
using Cricket_Match_Ticket_Jassi.Data;

namespace Cricket_Match_Ticket_Jassi.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext _context;

        public IndexModel(Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext context)
        {
            _context = context;
        }

        public IList<Buss.Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Seat)
                .Include(c => c.Ticket).ToListAsync();
        }
    }
}
