using Concert.Data.Entities;

namespace Concert.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketAsync();
        }

        private async Task CheckTicketAsync()
        {
            if (! _context.Tickets.Any())
            {
                for (int i = 1; i <= 1250; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        Codigo = i,
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrace = new Entrace { Description = "Norte" }

                    });
                }
                for (int i = 1251; i <= 2500; i++)
                {
                    _context.Tickets.Add(new Ticket
                    { 
                        Codigo=i,
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrace = new Entrace { Description = "Sur" }

                    });
                }
                for (int i = 2501; i <= 3750; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        Codigo = i,
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrace = new Entrace { Description = "Oriente" }

                    });
                }
                for (int i = 3751; i <= 5000; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        Codigo = i,
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrace = new Entrace { Description = "Occidente" }

                    });
                }
                await _context.SaveChangesAsync();

            }
        }

        
    }
}

