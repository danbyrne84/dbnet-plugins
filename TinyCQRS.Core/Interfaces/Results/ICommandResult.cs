namespace TinyCQRS.Core.Interfaces.Results
{
    public interface ICommandResult
    {
        bool Success { get; set; }
    }
}