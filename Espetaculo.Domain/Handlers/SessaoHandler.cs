using Espetaculos.Domain.Commands;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;
using Espetaculos.Shared.Commands;
using Espetaculos.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Handlers
{
    public class SessaoHandler : Notifiable, IHandler<CreateSessaoCommand>
    {
        private readonly IEspetaculoRepository _espetaculoRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoHandler(IEspetaculoRepository espetaculoRepository, ISalaRepository salaRepository, ISessaoRepository sessaoRepository)
        {
            _espetaculoRepository = espetaculoRepository;
            _salaRepository = salaRepository;
            _sessaoRepository = sessaoRepository;
        }
        // Buscar dados do espetaculo
        // Buscar dados da sala
        // Verificar se o horario esta disponivel
        // Cadastrar Sessao
        public ICommandResult Handle(CreateSessaoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            if (_sessaoRepository.IsHorarioFree(command.Horario, command.SalaId))
                return new GenericCommandResult(false, "O horario na sala especificada esta ocupado");

            var espetaculo = _espetaculoRepository.GetById(command.EspetaculoId);
            var sala = _salaRepository.GetById(command.SalaId);
            var sessao = new Sessao(command.Horario, espetaculo, sala, command.ValorIngresso);

            AddNotifications(sessao);

            if(Invalid) 
                return new GenericCommandResult(false, "Não foi possivel criar a sessão", this.Notifications);

            _sessaoRepository.Add(sessao);

            return new GenericCommandResult(true, "Sessão criada com sucesso");
        }
    }
}