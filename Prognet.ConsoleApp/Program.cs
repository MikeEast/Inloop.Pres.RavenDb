using System;
using System.Linq;
using System.Text;
using System.Transactions;
using Raven.Abstractions.Data;
using Raven.Abstractions.Indexing;
using Raven.Client.Changes;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace Prognet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentStore = new DocumentStore
            {
                Url = "ENTER URL HERE",
                ApiKey = "ENTER API KEY HERE IF ANY"

            };
            documentStore.Initialize();
            IndexCreation.CreateIndexes(typeof(User).Assembly, documentStore);
            
            using (var session = documentStore.OpenSession())
            {
                
            }
        }
    }
}