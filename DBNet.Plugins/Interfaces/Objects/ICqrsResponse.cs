using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBNet.Plugins.Interfaces.Objects
{
    public interface ICqrsResponse
    {
        bool Success { get; set; }
    }
}
