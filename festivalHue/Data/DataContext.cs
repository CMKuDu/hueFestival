using festivalHue.Models;
using Microsoft.EntityFrameworkCore;

namespace festivalHue.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Deatailbookticket> Deatailbookticket { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <Ticket> Tickets { get; set; }
        public DbSet<Tickettype> Tickettypes { get; set; }
        public DbSet<Transacstatus> Transacstatus { get; set; }

    }
}
