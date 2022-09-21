using Microsoft.EntityFrameworkCore;

namespace ApiLetsBurguer.Models
{
    public class FuncContext : DbContext
    {

        public FuncContext(DbContextOptions<FuncContext> options) : base(options)

        {
            Database.EnsureCreated();
        }

        public DbSet<Func> Funcionarios { get; set; }
    }
}
