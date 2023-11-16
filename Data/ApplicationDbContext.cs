using Hotels.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Data
{
    public class ApplicationDbContext: DbContext
    {
        //Constructior
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }

        public DbSet<Card> cards { get; set; }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<RoomDetails> roomDetails { get; set; }
        public DbSet<Room> rooms { get; set; }

    }
}
