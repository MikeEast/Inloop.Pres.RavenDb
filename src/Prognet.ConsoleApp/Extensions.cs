using Raven.Imports.Newtonsoft.Json;

namespace Prognet.ConsoleApp
{
    static class Extensions
    {
        public static string AsJson(this object serializee)
        {
            return JsonConvert.SerializeObject(serializee);
        }
    }
}