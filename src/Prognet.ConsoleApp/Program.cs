using System;
using Raven.Client.Document;

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
            
            using (var session = documentStore.OpenSession())
            {
                
            }

            Console.ReadKey(true);
        }
    }


    /*
    
    IndexCreation.CreateIndexes(typeof(Program).Assembly, documentStore);
    documentStore.RegisterListener(new ConsoleLogDocumentListener());
    
    var company = new Company
    {
        Name = "Know IT",
        ExternalId = "KNWIT",
        Address = new Address {  },
        Contact = new Contact { }
    };
    */
}