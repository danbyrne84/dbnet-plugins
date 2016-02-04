using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Interfaces.Results;

namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface IQueryHandler<in T, out TR> where T : IQuery<T, TR>
    {
        TR Handle(T query);
    }
}
