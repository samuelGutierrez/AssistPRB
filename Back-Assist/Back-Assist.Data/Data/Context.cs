using Back_Assist.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Back_Assist.Data.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public Context() { }

        public DbSet<LogSucursal> LogSucursales { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
