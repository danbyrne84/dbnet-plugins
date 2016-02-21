namespace TinyCQRS.Core.Interfaces.Objects
{
    public interface ICqrsResponse
    {
        bool Success { get; set; }
        dynamic Response { get; set; }
    }
}
