using TinyCQRS.Core.Interfaces.Handlers;
using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Handlers
{
    public abstract class QueryHandler<T, TR> : IQueryHandler<T, TR> where T : IQuery<T, TR> where TR : class
    {
        public abstract TR Handle(T query);
    }

}
