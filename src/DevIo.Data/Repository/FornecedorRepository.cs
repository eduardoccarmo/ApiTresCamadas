using DevIo.Business.Models;
using DevIo.Data.Context;
using DevIO.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevIo.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext db) : base(db) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fonecedores.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fonecedores.AsNoTracking()
               .Include(e => e.Endereco)
               .Include(p => p.Produtos)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            Db.Enderecos.Remove(endereco);
            await SaveChanges();
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }
    }
}
