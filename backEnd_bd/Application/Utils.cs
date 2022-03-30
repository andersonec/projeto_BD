using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace backEnd_bd.Application
{
    public static class Utils
    {
        public static string Serializar<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof (T));
            MemoryStream ms = new MemoryStream();

            serializer.WriteObject(ms, obj);

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public static T DeSerializar<T>(string json)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return (T)deserializer.ReadObject(ms);
        }
    }
}
