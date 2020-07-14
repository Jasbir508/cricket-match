using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cricket_Match_Ticket_Jassi.Buss;
using Cricket_Match_Ticket_Jassi.Data;

namespace Cricket_Match_Ticket_Jassi.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext _context;

        public CreateModel(Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SeatID"] = new SelectList(_context.Seats, "ID", "SeatNumber");
        ViewData["TicketID"] = new SelectList(_context.Tickets, "ID", "Number");
            return Page();
        }

        [BindProperty]
        public Buss.Customer Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
