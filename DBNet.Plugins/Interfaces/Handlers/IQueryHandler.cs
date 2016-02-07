using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Interfaces.Handlers
{
    public interface IQueryHandler<in T, out TR> : IQueryHandler where T : IQuery<T, TR>
    {
        TR Handle(T query);
    }

    public interface IQueryHandler : IHandler
    {
        
    }
}
