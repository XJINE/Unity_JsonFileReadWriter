using System.Text;
using System.Xml.Serialization;

namespace System.IO
{
    public class XmlUtility
    {
        public static string ToXml<T>(T obj)
        {
            return Serialzie<T>(obj, Encoding.UTF8);
        }

        public static string ToXml<T>(T obj, Encoding encoding)
        {
            return Serialzie<T>(obj, encoding);
        }

        public static T FromXml<T>(string xml)
        {
            return Deserialize<T>(xml, Encoding.UTF8);
        }

        public static T FromXml<T>(string xml, Encoding encoding)
        {
            return Deserialize<T>(xml, encoding);
        }

        private static string Serialzie<T>(T obj, Encoding encoding)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream, encoding))
                {
                    serializer.Serialize(writer, obj);
                    return encoding.GetString(stream.ToArray());
                }
            }
        }

        private static T Deserialize<T>(string xml, Encoding encoding)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                return (T)serializer.Deserialize(memoryStream);
            }
        }
    }
}