using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBNet.Plugins.Example.Datastore;
using DBNet.Plugins.Interfaces.Handlers;

namespace DBNet.Plugins.Example
{
    public class HelloWorldQueryHandler : IQueryHandler<HelloWorldQuery, HelloWorldQueryResult>
    {
        private readonly MemoryDataStore _datastore = new MemoryDataStore();
        private const string UnknownUser = "Unknown User";

        public HelloWorldQueryResult Handle(HelloWorldQuery query)
        {
            string userName;

            try
            {
                userName = _datastore.Store.First(x => x.Key == query.UserId.ToString()).Value as string 
                    ?? UnknownUser;
            }
            catch (InvalidOperationException)
            {
                userName = UnknownUser;
            }

            return new HelloWorldQueryResult { UserName = userName };
        }
    }

    public class HelloWorldQueryResult
    {
        public string UserName { get; set; }
    }
}
