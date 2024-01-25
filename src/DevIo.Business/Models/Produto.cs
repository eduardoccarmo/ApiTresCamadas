﻿namespace DevIo.Business.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        #region Entity Framework Relationships

        public Fornecedor Fornecedor { get; set; }

        #endregion
    }
}
