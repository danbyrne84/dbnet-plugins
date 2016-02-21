namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface IQuery<T, TR> : IQuery
    {
        
    }

    public interface IQuery : IAction
    {

    }
}