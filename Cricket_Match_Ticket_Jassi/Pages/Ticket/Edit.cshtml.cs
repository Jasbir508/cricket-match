using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cricket_Match_Ticket_Jassi.Buss;
using Cricket_Match_Ticket_Jassi.Data;

namespace Cricket_Match_Ticket_Jassi.Pages.Ticket
{
    public class EditModel : PageModel
    {
        private readonly Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext _context;

        public EditModel(Cricket_Match_Ticket_Jassi.Data.Cricket_Match_Ticket_JassiDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buss.Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.ID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.ID == id);
        }
    }
}
