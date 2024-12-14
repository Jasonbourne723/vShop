using MediatR;

namespace vShop.Apps.Application.Commands
{
    public interface ICommandHandler<in T> : IRequestHandler<T> where T : ICommand
    {

    }

    public interface ICommandHandler<in T, TResponse> : IRequestHandler<T, TResponse> where T : ICommand<TResponse>
    {

    }
}
