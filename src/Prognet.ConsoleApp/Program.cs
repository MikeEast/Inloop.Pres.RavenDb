using System;
using System.Linq;
using System.Threading;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Imports.Newtonsoft.Json.Converters;

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
     
    * Paging:
     
        RavenQueryStatistics stats;

        // get the first page
        var results = session.Query<Company>()
            .Statistics(out stats)
            .Skip(0 * 10) // retrieve results for the first page
            .Take(10) // page size is 10
            .Distinct()
            .ToArray();
        var totalResults = stats.TotalResults;
        var skippedResults = stats.SkippedResults;

        foreach (var result in results)
        {
            Console.WriteLine(result.Name);
        }

        Console.WriteLine(stats.AsJson());

        // get the second page
        results = session.Query<Company>()
            .Statistics(out stats)
            .Skip((1 * 10) + skippedResults) // retrieve results for the second page, taking into account skipped results
            .Take(10) // page size is 10
            .Distinct()
            .ToArray();

        foreach (var result in results)
        {
            Console.WriteLine(result.Name);
        }

        Console.WriteLine(stats.AsJson());
    */
}