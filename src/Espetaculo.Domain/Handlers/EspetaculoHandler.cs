using Espetaculos.Domain.Commands;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;
using Espetaculos.Shared.Commands;
using Espetaculos.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Handlers
{
    public class EspetaculoHandler : Notifiable, IHandler<CreateEspetaculoCommand>
    {
        private readonly IEspetaculoRepository _espetaculoRepository;

        public EspetaculoHandler(IEspetaculoRepository espetaculoRepository)
        {
            _espetaculoRepository = espetaculoRepository;
        }

        public ICommandResult Handle(CreateEspetaculoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            if (_espetaculoRepository.EspetaculoNameExist(command.Nome))
                return new GenericCommandResult(false, "Já existe um espetáculo com esse nome");

            var espetaculo = new Espetaculo(command.Nome, command.Descricao, command.DuracaoMinutos);
            
            _espetaculoRepository.Add(espetaculo);

            return new GenericCommandResult(true, "Espetaculo Cadastrado com sucesso");
        }
    }
}