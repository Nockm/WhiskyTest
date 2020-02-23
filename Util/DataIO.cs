using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Serialization;

namespace WhiskyTest.Util
{
    class DataIO
    {
        public static TObject XmlToObj<TObject>(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TObject));
            var stringReader = new StringReader(xml);
            TObject obj = (TObject)xmlSerializer.Deserialize(stringReader);
            return obj;
        }

        public static string ObjToXml<TObject>(TObject obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TObject));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, obj);
            string str = stringWriter.ToString();
            return str;
        }

        public static TObject XmlFileToObj<TObject>(string xmlFile)
        {
            string xml = File.ReadAllText(xmlFile);
            return XmlToObj<TObject>(xml);
        }

        public static void ObjToXmlFile<TObject>(TObject obj, string xmlFile)
        {
            string xml = ObjToXml(obj);
            File.WriteAllText(xmlFile, xml);
        }

        public static string ResourceToString(string resourceUri)
        {
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(new System.Uri(resourceUri, System.UriKind.Relative));
            Stream stream = streamResourceInfo.Stream;
            StreamReader streamReader = new StreamReader(stream);
            string str = streamReader.ReadToEnd();
            return str;
        }

        public static TObject XmlResourceToObj<TObject>(string resourceUri)
        {
            string xml = ResourceToString(resourceUri);
            return XmlToObj<TObject>(xml);
        }
    }
}
