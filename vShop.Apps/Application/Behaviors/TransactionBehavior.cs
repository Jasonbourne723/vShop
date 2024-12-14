using MediatR;
using Microsoft.EntityFrameworkCore;
using vShop.Apps.Application.Commands;
using vShop.Infrastructure;

namespace vShop.Apps.Application.Behaviors
{
    public class TransactionBehavior<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
        private readonly EFContext _eFContext;

        public TransactionBehavior(EFContext eFContext)
        {
            this._eFContext = eFContext;
        }

        public async Task<TResponse> Handle(TCommand request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = default(TResponse);
            var strategy = _eFContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _eFContext.Database.BeginTransaction();

                response = await next();

                await transaction.CommitAsync();

            });

            return response!;
        }
    }
}
