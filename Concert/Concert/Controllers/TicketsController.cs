#nullable disable
using Concert.Data;
using Concert.Data.Entities;
using Concert.Helpers;
using Concert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concert.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public TicketsController(DataContext context, ICombosHelper combos)
        {
            _context = context;
            _combosHelper = combos;
        }

        public async Task<IActionResult> Register() 
        {
               return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(int? id)
        {         
                      
            if (ModelState.IsValid)
            {                                               
                try
                {
                    Ticket ticket = await _context.Tickets.FindAsync(id);
                    if (ticket == null)
                    {
                        try
                        { 
                        }
                        catch (Exception exception)
                        {
                            ModelState.AddModelError(string.Empty, "La boleta no existe");
                        }
                
                    }

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
               
               
            }
                                  
            
            return RedirectToAction(nameof(Edit), new { Id = id }) ;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            TicketViewModel model = new()
            {
                Id = ticket.Id,
                Entrace = await _combosHelper.GetComboEntraceAsync()
        };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            
                        
            if (ModelState.IsValid)
            {
                try
                {
                    Ticket ticket = new()
                    {
                        Id=model.Id,
                        WasUsed = true,
                        Date = DateTime.Now,
                        Document = model.Document,
                        Name = model.Name,
                        Entrace = await _context.Entraces.FirstOrDefaultAsync(m => m.Id == model.EntraceId)
                    };
                    
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

      
    }
}
