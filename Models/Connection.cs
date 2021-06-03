using Microsoft.EntityFrameworkCore;

namespace WCS_Test_Backend.Models
{
    public class Connection: DbContext
    {
        public Connection(DbContextOptions<Connection> options): base(options) {}

        public DbSet<Admission> Admissions { get; set; }
    }
}