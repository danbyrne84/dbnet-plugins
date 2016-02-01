using System;

namespace DBNet.Plugins.Model
{
    public interface ICqrsResponse
    {
        bool Success { get; set; }
        Guid RequestId { get; set; }
    }
}
