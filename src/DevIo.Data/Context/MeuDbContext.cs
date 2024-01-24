using DevIo.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIo.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fonecedores { get; set; }

    }
}
