using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Handlers
{
    public abstract class QueryHandler<T, TR> : QueryHandler, IQueryHandler<T, TR> where T : IQuery<T, TR> where TR : class
    {
        public virtual TR Handle(T query)
        {
            return default(TR);
        }
    }

    public class QueryHandler : Handler, IQueryHandler
    {

    }
}
