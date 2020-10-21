using System.Collections.Generic;
using System.Linq;
using Espetaculos.Domain.Commands;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;
using Espetaculos.Domain.Utils;
using Espetaculos.Shared.Commands;
using Espetaculos.Shared.Handlers;
using Flunt.Notifications;

namespace Espetaculos.Domain.Handlers
{
    public class ReservaHandler : Notifiable, IHandler<CreateReservaCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ISessaoRepository _sessaoRepository;
        private readonly IReservaRepository _reservaRepository;

        public ReservaHandler(IClienteRepository clienteRepository, ISessaoRepository sessaoRepository, IReservaRepository reservaRepository)
        {
            _clienteRepository = clienteRepository;
            _sessaoRepository = sessaoRepository;
            _reservaRepository = reservaRepository;
        }

        //Cadastrar a reserva não quer dizer que ela foi comprada
        // Tera um handler para confirmar reserva
        // Ai sim é persistido, mas para outras pessoas, a reserva ja foi feita
        public ICommandResult Handle(CreateReservaCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);

            var cliente = _clienteRepository.GetById(command.ClienteId);
            var sessao = _sessaoRepository.GetById(command.SessaoId);
            var poltronas = _sessaoRepository.GetPoltronasByIds(ExtractGuids.Extract(command));

            //Verificar se poltronas estão ocupadas
            if (IsPoltronasOcuped(poltronas))
                return new GenericCommandResult(false, "Algumas poltronas selecionadas já estão ocupadas", poltronas);

            var reserva = new Reserva(cliente, sessao);
            reserva.AdicionarIngresso(CreateIngressos(command.Ingressos, poltronas));

            AddNotifications(reserva);

            if (Invalid)
                return new GenericCommandResult(false, "Problema ao gerar reserva", this.Notifications);

            _reservaRepository.Add(reserva);

            return new GenericCommandResult(true, "Reserva feita com sucesso", reserva);
            //Verifica o estado das poltronas 
            //Utilizar Dapper ou buscar estas informações na tela
        }

        
        public IEnumerable<Ingresso> CreateIngressos(IEnumerable<CreateIngressoCommand> ingressoCommands, IEnumerable<Poltrona> poltronas)
        {
            return ingressoCommands.Join(
                        poltronas,
                        ingresso => ingresso.PoltronaId,
                        poltrona => poltrona.Id,
                        (ingresso, poltrona) => new Ingresso(ingresso.NomeCliente, poltrona)
                    );
        }
        public bool IsPoltronasOcuped(IEnumerable<Poltrona> poltronas) => poltronas.Any(poltrona => poltrona.Ocupada);
    }
}