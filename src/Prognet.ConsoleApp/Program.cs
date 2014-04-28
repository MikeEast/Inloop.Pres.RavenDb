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
                Url = "http://localhost:8080",
                DefaultDatabase = "Test"
            };
            documentStore.Initialize();
            IndexCreation.CreateIndexes(typeof(User).Assembly, documentStore);
            
            using (var session = documentStore.OpenSession())
            {
                var user = new User("Micke");
                session.Store(user);
                session.SaveChanges();
            }
        }
    }
}