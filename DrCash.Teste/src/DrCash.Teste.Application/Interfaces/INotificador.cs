using DrCash.Teste.Application.Notificacoes;
using System.Collections.Generic;

namespace DrCash.Teste.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}