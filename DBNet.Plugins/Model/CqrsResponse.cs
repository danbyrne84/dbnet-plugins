using System;
using DBNet.Plugins.Interfaces.Objects;

namespace DBNet.Plugins.Model
{
    public class CqrsResponse : ICqrsResponse
    {
        public bool Success { get; set; }
    }
}
