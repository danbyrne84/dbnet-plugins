using TinyCQRS.Core.Interfaces.Results;

namespace TinyCQRS.Core.Model.Results
{
    public class QueryResult<T> : IQueryResult<T> where T : class
    {
        public T Result { get; set; }
        public bool Success { get; }
    }
}
