using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Vertem.Agrega.Test
{
    public class FilterDefinitionTester
    {
        public static string[] GetUpdate<T>(UpdateDefinition<T> upd)
        {
            var bval = upd.Render(BsonSerializer.LookupSerializer<T>(), BsonSerializer.SerializerRegistry);
            return bval[0].AsBsonDocument.ToArray().Select(b => b.ToString()).ToArray();
        }

        public static IDictionary<string, string> GetFilters<T>(FilterDefinition<T> flt)
        {
            var bdoc = flt.Render(BsonSerializer.LookupSerializer<T>(), BsonSerializer.SerializerRegistry);            
            return bdoc.ToArray().ToDictionary(b => b.Name, b => b.ToString());
        }
    }
}
