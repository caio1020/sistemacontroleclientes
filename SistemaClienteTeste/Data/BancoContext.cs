using Microsoft.EntityFrameworkCore;
using SistemaClienteTeste.Models;

namespace SistemaClienteTeste.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
