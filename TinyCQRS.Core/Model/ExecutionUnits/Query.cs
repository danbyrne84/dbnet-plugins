using TinyCQRS.Core.Interfaces.Objects;
using TinyCQRS.Core.Model.Internal;

namespace TinyCQRS.Core.Model.ExecutionUnits
{
    public class Query<T,TR> : Query, IQuery<T, TR>
    {
        public string ReturnType
        {
            get
            {
                return GetType().GetGenericArguments()[1].FullName;
            }
            set { }
        }
    }

    public class Query : Action
    {
    }
}