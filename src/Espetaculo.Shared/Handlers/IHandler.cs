using Espetaculos.Shared.Commands;

namespace Espetaculos.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand {
        
        ICommandResult Handle(T command);
    }
}