using DevIo.Business.Notificacoes;

namespace DevIo.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes(); 
        void Handle(Notificacao notificacao);
    }
}
