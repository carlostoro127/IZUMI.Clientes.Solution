using Microsoft.EntityFrameworkCore;
using IZUMI.Clientes.Shared.Models;

namespace IZUMI.Clientes.API.Data
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}
