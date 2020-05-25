using System.Text;
using System.Runtime.Serialization.Json;

namespace System.IO
{
    public static class DataContractJsonUtility
    {
        // NOTE:
        // DataContractJsonSerializer considers 
        // [DataMember(Name="x")], [IgnoreDataMember] and any other attributes.

        #region Method

        public static string ToJson<T>(T obj)
        {
            return Serialize<T>(obj, Encoding.UTF8);
        }

        public static string ToJson<T>(T obj, Encoding encoding)
        {
            return Serialize<T>(obj, encoding);
        }

        public static T FromJson<T>(string json)
        {
            return Deserialize<T>(json, Encoding.UTF8);
        }

        public static T FromJson<T>(string json, Encoding encoding)
        {
            return Deserialize<T>(json, encoding);
        }

        private static string Serialize<T>(T obj, Encoding encoding)
        {
            var memoryStream = new MemoryStream();
            var serializer   = new DataContractJsonSerializer(typeof(T));

            serializer.WriteObject(memoryStream, obj);
 
            byte[] bytes = memoryStream.ToArray();  
            string json  = encoding.GetString(bytes, 0, bytes.Length);

            memoryStream.Dispose();

            return json;
        }

        private static T Deserialize<T>(string json, Encoding encoding)
        {
            var memoryStream = new MemoryStream(encoding.GetBytes(json));
            var serializer   = new DataContractJsonSerializer(typeof(T));

            var serializedObject = (T)serializer.ReadObject(memoryStream);

            memoryStream.Dispose();

            return serializedObject;
        }

        #endregion Method
    }
}