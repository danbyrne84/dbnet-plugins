namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface IHandlerFactory
    {
        ICqrsResponse Handle(IAction action);
    }
}