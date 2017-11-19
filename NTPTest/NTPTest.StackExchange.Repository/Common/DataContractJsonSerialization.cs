using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace NTPTest.StackExchange.Repository.Common
{
    /// <summary>
    /// Helper methods for serialization with <code>DataContractSerializer</code>.
    /// </summary>
    public static class DataContractJsonSerialization
    {
        public static TEntity Deserialize<TEntity>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(TEntity));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                ms.Position = 0;
                return (TEntity)serializer.ReadObject(ms);
            }
        }

        public static string Serialize<TEntity>(TEntity serializeObject)
        {
            var serializer = new DataContractJsonSerializer(typeof(TEntity));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, serializeObject);
                ms.Position = 0;
                var sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
        }
    }
}
