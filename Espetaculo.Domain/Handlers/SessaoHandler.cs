using Espetaculos.Domain.Commands;
using Espetaculos.Domain.Repositories;
using Espetaculos.Shared.Commands;
using Espetaculos.Shared.Handlers;

namespace Espetaculos.Domain.Handlers {
    public class SessaoHandler : IHandler<CreateSessaoCommand>
    {
        private readonly IEspetaculoRepository _espetaculoRepository;

        public SessaoHandler(IEspetaculoRepository espetaculoRepository)
        {
            _espetaculoRepository = espetaculoRepository;
        }

        public ICommandResult Handle(CreateSessaoCommand command)
        {
            // Buscar dados do espetaculo
            // Buscar dados da sala
            // Verificar se o horario esta disponivel
            // Cadastrar Sessao



            return null;   
        }
    }
}