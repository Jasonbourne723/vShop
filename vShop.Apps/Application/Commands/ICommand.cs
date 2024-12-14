using MediatR;

namespace vShop.Apps.Application.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {

    }

    public interface ICommand : IRequest
    {

    }


}
