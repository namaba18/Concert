using Concert.Data.Entities;
using Concert.Helpers;

namespace Concert.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public SeedDb(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketAsync();
            await CheckEntraceAsync();
        }

        private async Task CheckEntraceAsync()
        {
            _context.Entraces.Add(new Entrace { Description = "Norte" });
            _context.Entraces.Add(new Entrace { Description = "Sur" });
            _context.Entraces.Add(new Entrace { Description = "Oriental" });
            _context.Entraces.Add(new Entrace { Description = "Occidental" });
            await _context.SaveChangesAsync();

        }

        private async Task CheckTicketAsync()
        {
            if (! _context.Tickets.Any())
            {
                for (int i = 0; i < 5000; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {                        
                        WasUsed = false,
                        Document = null,
                        Name = null,
                        Date = null,
                        Entrace = null

                    });
                }
                
                await _context.SaveChangesAsync();

            }


        }

        
    }
}

