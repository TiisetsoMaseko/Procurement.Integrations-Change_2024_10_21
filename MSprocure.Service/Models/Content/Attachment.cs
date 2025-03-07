using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("Attachment")]
    public class Attachment
    {
        [XmlAttribute("visibility")]
        public string visibility { get; set; }

        [XmlElement("Url")]
        public URL URL { get; set; }
    }
#pragma warning restore IDE1006
}
