using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content
{
    [XmlRoot("Hazard")]
    public class Hazard
    {
        //[XmlElement("Description", IsNullable = true)]
        //public Description Description { get; set; }

        [XmlElement("Classification", IsNullable = true)]
        public Classification Classification { get; set; }



    }
}
