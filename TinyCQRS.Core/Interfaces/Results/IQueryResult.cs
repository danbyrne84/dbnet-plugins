namespace TinyCQRS.Core.Interfaces.Results
{
    public interface IQueryResult<T> where T : class
    {
        T Result { get; set; }
        bool Success { get; }
    }
}