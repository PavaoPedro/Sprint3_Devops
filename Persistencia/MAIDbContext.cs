using MAI.Models;
using Microsoft.EntityFrameworkCore;

namespace MAI.Persistencia
{
    public class MAIDbContext : DbContext
    {
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Regiao> Regiao { get; set; }


        public MAIDbContext(DbContextOptions<MAIDbContext> options) : base(options)
        {

        }
    }
}
