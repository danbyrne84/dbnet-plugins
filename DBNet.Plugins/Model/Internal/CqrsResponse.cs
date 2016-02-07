using TinyCQRS.Core.Interfaces.Objects;

namespace TinyCQRS.Core.Model.Internal
{
    internal class CqrsResponse : ICqrsResponse
    {
        public bool Success { get; set; }
    }
}
