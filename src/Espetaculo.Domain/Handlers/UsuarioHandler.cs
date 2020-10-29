using Espetaculos.Domain.Commands;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.Repositories;
using Espetaculos.Domain.Utils;
using Espetaculos.Domain.ValueObjects;
using Espetaculos.Shared.Commands;
using Espetaculos.Shared.Handlers;
using Flunt.Notifications;

namespace Espetaculos.Domain.Handlers
{
    public class UsuarioHandler : Notifiable,
        IHandler<LoginCommand>, IHandler<RegisterClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public UsuarioHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        public ICommandResult Handle(LoginCommand command)
        {
            if(!command.Validate()) 
                return new GenericCommandResult(false, "Informações inválidas para prosseguir com o login", command.Notifications);
                
            var _user = _clienteRepository.GetByEmail(command.Email);

            if(_user.IsNull() || !Hash.Compare(command.Senha, _user.Usuario.Senha))
                return new GenericCommandResult(false,"E-mail ou senha inválidos");
            
            return new GenericCommandResult(true, "Usuário autenticado com sucesso", _user);
        }

        public ICommandResult Handle(RegisterClienteCommand command)
        {
            if(!command.Validate())
                return new GenericCommandResult(false, "Informações inválidas", command.Notifications);

            if(_clienteRepository.UserExist(command.Email))
                return new GenericCommandResult(false,"E-mail já cadastrado");

            var email = new Email(command.Email);
            var usuario = new Usuario(email, Hash.Encript(command.Senha), ETipoUsuario.Cliente);
            var cliente = new Cliente(command.Nome,command.Sobrenome,usuario);

            _clienteRepository.Save(cliente);

            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", cliente);
        }
    }
}