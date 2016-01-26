using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Interfaces.Objects;
using DBNet.Plugins.Interfaces.Results;

namespace DBNet.Plugins.Interfaces.Handlers
{
    public interface IQueryHandler<T> where T : IQuery<T>
    {
        IQueryResult<TR> Handle<TR>(T query) where TR : IQueryResult<T>;
    }
}
