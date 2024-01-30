using DevIo.Business.Interfaces;
using DevIo.Business.Notificacoes;
using DevIo.Data.Context;
using DevIo.Data.Repository;
using DevIO.Business.Interfaces;
using DevIO.Business.Services;

namespace DevIo.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
