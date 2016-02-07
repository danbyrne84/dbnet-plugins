namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface IQuery<T, TR> : IAction
    {
        string ReturnType { get; }
    }
}