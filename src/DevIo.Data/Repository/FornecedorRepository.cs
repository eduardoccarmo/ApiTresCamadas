using DevIo.Business.Models;
using DevIo.Data.Context;
using DevIO.Business.Interfaces;

namespace DevIo.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext db) : base(db) { }

        public Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
