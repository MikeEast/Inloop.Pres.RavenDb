using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    public class Search_View : AbstractMultiMapIndexCreationTask<SearchHit>
    {
        public Search_View()
        {
            this.AddMap<Company>(company =>
                from c in company
                select new
                {
                    Id = c.Id,
                    Title = c.Name,
                    Type = "Company"
                }
            );

            this.AddMap<Employee>(employees =>
                from e in employees
                select new
                {
                    Id = e.Id,
                    Title = e.FirstName + " " + e.LastName,
                    Type = "Enployee"
                }
            );

            Reduce = hits =>
                from h in hits
                group h by h.Id
                into g
                let f = g.First()
                select new
                {
                    Id = g.Key,
                    f.Title,
                    f.Type
                };

            this.Index(s => s.Title, FieldIndexing.Analyzed);
        }
    }

    public class SearchHit
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public object Document { get; set; }
    }


    /*
     * Usage:
        RavenQueryStatistics stats;
        var searchHits = session.Advanced
            .LuceneQuery<SearchHit, Search_View>()
            .WhereStartsWith(s => s.Title, "B")
            .Statistics(out stats)
            .ToList();
        var searchResult = new 
        {
            TotalHits = stats.TotalResults,
            SearchHits = searchHits
        };

        foreach (var searchHit in searchHits)
        {
            Console.WriteLine(searchHit.AsJson());
        }
     
     */
}
