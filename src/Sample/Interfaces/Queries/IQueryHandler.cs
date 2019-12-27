using System.Threading.Tasks;

namespace Sample.Interfaces.Queries
{
    public interface IQueryHandler<in TRequest, out TResponse>
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>
    {
        TResponse Handle(TRequest input);
    }
}