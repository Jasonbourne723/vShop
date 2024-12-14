using FluentValidation;
using MediatR;
using vShop.Apps.Application.Commands;

namespace vShop.Apps.Application.Behaviors
{
    public class ValidationBehavior<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TCommand>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TCommand>> validators)
        {
            this._validators = validators;
        }

        public async Task<TResponse> Handle(TCommand request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException("Validation exception", failures);
            }

            return await next();
        }
    }
}
