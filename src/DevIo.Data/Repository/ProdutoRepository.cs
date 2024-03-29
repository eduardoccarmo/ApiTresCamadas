﻿using DevIo.Business.Models;
using DevIo.Data.Context;
using DevIO.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevIo.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext db) : base(db) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                 .Include(f => f.Fornecedor)
                 .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                 .Include(f => f.Fornecedor)
                 .OrderBy(p => p.Nome)
                 .ToListAsync(); 
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
