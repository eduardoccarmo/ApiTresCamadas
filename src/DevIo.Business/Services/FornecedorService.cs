using DevIo.Business.Interfaces;
using DevIo.Business.Models;
using DevIo.Business.Models.Validations;
using DevIo.Business.Services;
using DevIO.Business.Interfaces;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidations(), fornecedor) || !ExecutarValidacao(new EnderecoValidations(), fornecedor.Endereco))
                return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor cadastrado com este documento.");

                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidations(), fornecedor))
                return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor cadastrado com este documento.");

                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null)
            {
                Notificar($"Não existe fornecedor cadastrado com o id {id}.");

                return;
            }

            if (fornecedor.Produtos.Any())
            {
                Notificar("Não é possível remover o fornecedor pois ele possuí produtos cadastrados, exclua-os antes de remover o fornecedor.");

                return;
            }

            var endereco = _fornecedorRepository.ObterFornecedorEndereco(id);

            if (endereco != null)
            {
                Notificar("Não é possível remover o fornecedor pois ele possuí endereço cadastrados, exclua-o antes de remover o fornecedor.");

                return;
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
