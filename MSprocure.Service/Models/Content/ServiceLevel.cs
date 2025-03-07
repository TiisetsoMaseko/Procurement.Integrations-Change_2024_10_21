using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content
{
    [XmlRoot("ServiceLevel")]
    public class ServiceLevel
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("xml:lang")]
        public string Lang { get; set; }

    }
}
