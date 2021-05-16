using System.Collections.Generic;
using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// ParliamentXML type
    /// </summary>
    [XmlRoot(ElementName = "ArrayOfMemberOfParliament")]
    public class ArrayOfMemberOfParliament
    {
        [XmlElement(ElementName = "MemberOfParliament")]
        public List<GovernmentMemberOfParliament> MemberOfParliament { get; set; }
    }
}
