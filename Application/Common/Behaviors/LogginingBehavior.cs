using Serilog;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;

namespace Application.Common.Behaviors
{
    public class LogginingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        ICurrentUserService _currentUserService;

        public LogginingBehavior(ICurrentUserService currentUserService) =>
            _currentUserService = currentUserService;
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var position = _currentUserService.Position;

            Log.Information("Staff Request: {Name} {@Position} {@Request}",
                requestName, position, request);

            var response = await next();

            return response;
        }

        
    }
}
