using Microsoft.EntityFrameworkCore;

namespace Hotel.Model.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC-232-11\SQLEXPRESS;Initial Catalog=Hotel;User ID=sa;Password=4321193");
        }


        

    }
}
