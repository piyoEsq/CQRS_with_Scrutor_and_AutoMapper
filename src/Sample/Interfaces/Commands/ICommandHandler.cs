using System.Threading.Tasks;

namespace Sample.Interfaces.Commands
{
    public interface ICommandHandler<TRequest> where TRequest : ICommand
    {
         void Handle(TRequest input);
    }
}