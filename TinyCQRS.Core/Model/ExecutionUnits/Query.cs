using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model.ExecutionUnits
{
    public class Query<T,TR> : Query, IQuery<T, TR>
    {
        public string ReturnType => GetType().GetGenericArguments()[1].FullName;
    }

    public class Query : Action
    {
    }
}