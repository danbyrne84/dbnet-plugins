using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface IHandler
    {
        string Name { get; }
        string Type { get; set; }
        string Description { get; set; }

        bool CanHandle(IAction action);
        ICqrsResponse Handle(IAction action);
    }

    public interface IHandler<in T, out TR> where T : IAction where TR : class
    {
        TR Handle(T action);
    }

}