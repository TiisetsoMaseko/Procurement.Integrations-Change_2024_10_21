using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MSprocure.Service.Helpers
{
    public static class SerializeHelper
    {
    #pragma warning disable CA2200, CS8600, CS8601, CS8603, CS0168 // Ignore Naming Rule Violations

        public static string SerializeString<T>(ref T obj, out bool success, string xmlHeader = "", string cXmlVersion = "")
        {
            success = false;
            var result = "";
            if (string.IsNullOrEmpty(cXmlVersion)) cXmlVersion = "http://xml.cxml.org/schemas/cXML/1.2.059/cXML.dtd";

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Encoding = System.Text.Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document
                };

                using (var sw = new UTF8StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        var xns = new XmlSerializerNamespaces();
                        xns.Add(string.Empty, string.Empty);
                        xw.Formatting = Formatting.Indented;
                        xw.WriteDocType("cXML", null, cXmlVersion, null);
                        xmlSerializer.Serialize(xw, obj, xns);
                        success = true;
                    }

                    result = sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(xmlHeader)) return xmlHeader + "\r\n" + result;

            return result;
        }

        public static string SerializeStringInvoice<T>(ref T obj, out bool success, string xmlHeader = "", string cXmlVersion = "")
        {
            success = false;
            var result = "";
            if (string.IsNullOrEmpty(cXmlVersion)) cXmlVersion = "http://xml.cXML.org/schemas/cXML/1.2.059/InvoiceDetail.dtd";

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Encoding = System.Text.Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document
                };

                using (var sw = new UTF8StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        var xns = new XmlSerializerNamespaces();
                        xns.Add(string.Empty, string.Empty);
                        xw.Formatting = Formatting.Indented;
                        xw.WriteDocType("cXML", null, cXmlVersion, null);
                        xmlSerializer.Serialize(xw, obj, xns);
                        success = true;
                    }
                    result = sw.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(xmlHeader)) return xmlHeader + "\r\n" + result;

            return result;
        }

        public static string SerializeStringASN<T>(ref T obj, out bool success, string xmlHeader = "", string cXmlVersion = "")
        {
            success = false;
            var result = "";
            if (string.IsNullOrEmpty(cXmlVersion)) cXmlVersion = "http://xml.cXML.org/schemas/cXML/1.2.059/Fulfill.dtd";

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Encoding = System.Text.Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document
                };

                using (var sw = new UTF8StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        var xns = new XmlSerializerNamespaces();
                        xns.Add(string.Empty, string.Empty);
                        xw.Formatting = Formatting.Indented;
                        xw.WriteDocType("cXML", null, cXmlVersion, null);
                        xmlSerializer.Serialize(xw, obj, xns);
                        success = true;
                    }
                    result = sw.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(xmlHeader)) return xmlHeader + "\r\n" + result;

            return result;
        }

        public static string SerializeStringResponse<T>(ref T obj, out bool success, string xmlHeader = "", string cXmlVersion = "")
        {
            success = false;
            var result = "";
            if (string.IsNullOrEmpty(cXmlVersion)) cXmlVersion = "http://xml.cxml.org/schemas/cXML/1.2.059/cXML.dtd";

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Encoding = System.Text.Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document
                };

                using (var sw = new UTF8StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        var xns = new XmlSerializerNamespaces();
                        xns.Add(string.Empty, string.Empty);
                        xw.Formatting = Formatting.Indented;
                        xmlSerializer.Serialize(xw, obj, xns);
                        success = true;
                    }
                    result = sw.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(xmlHeader)) return xmlHeader + "\r\n" + result;

            return result;
        }

        public static string SerializeUrlEncodedString<T>(ref T obj, out bool success)
        {
            success = false;
            var result = "";
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Encoding = System.Text.Encoding.UTF8,
                    ConformanceLevel = ConformanceLevel.Document
                };

                using (var sw = new StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        var xns = new XmlSerializerNamespaces();
                        xns.Add(string.Empty, string.Empty);
                        xw.Formatting = Formatting.Indented;
                        xw.WriteDocType("cXML", null, "http://xml.cxml.org/schemas/cXML/1.2.059/cXML.dtd", null);
                        xmlSerializer.Serialize(xw, obj, xns);
                        success = true;
                    }
                    result = sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool DeserializeString<T>(ref string text, out T obj)
        {
            obj = default;
            var success = false;
            try
            {
                using (TextReader sr = new StringReader(text))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    obj = (T)xmlSerializer.Deserialize(sr);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw new XmlException("Request did not validate successfully with DTD.");
            }
            return success;
        }


        public static MSprocure.Service.Models.cXml ReadXml<T>(string XmlString)
        {
            using (var sw = new StringReader(XmlString))
            {
                return (MSprocure.Service.Models.cXml)new XmlSerializer(typeof(MSprocure.Service.Models.cXml)).Deserialize(sw);
            }
        }

        public class UTF8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    #pragma warning restore CA2200, CS8600, CS8601, CS8603, CS0168
    }
}
