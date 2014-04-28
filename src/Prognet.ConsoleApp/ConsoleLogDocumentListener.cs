using System;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace Prognet.ConsoleApp
{
    public class ConsoleLogDocumentListener : IDocumentStoreListener
    {
        public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
        {
            return true;
        }

        public void AfterStore(string key, object entityInstance, RavenJObject metadata)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Stored document. \t\nKey: {0}, \t\nEntity type: {1}, \t\nmeta: {2}", key, entityInstance != null ? entityInstance.GetType() : null, metadata);
        }
    }
}