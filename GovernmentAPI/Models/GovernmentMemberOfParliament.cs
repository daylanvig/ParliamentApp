using ParliamentApp.Models.Common;
using System;
using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// Member of parliament as represented by the government of canada's api
    /// </summary>
    [XmlRoot(ElementName = "MemberOfParliament")]
    public class GovernmentMemberOfParliament
    {
        [XmlElement(ElementName = "PersonShortHonorific")]
        public string PersonShortHonorific { get; set; }
        [XmlElement(ElementName = "PersonOfficialFirstName")]
        public string PersonOfficialFirstName { get; set; }
        [XmlElement(ElementName = "PersonOfficialLastName")]
        public string PersonOfficialLastName { get; set; }
        [XmlElement(ElementName = "ConstituencyName")]
        public string ConstituencyName { get; set; }
        [XmlElement(ElementName = "ConstituencyProvinceTerritoryName")]
        public Province ConstituencyProvinceTerritoryName { get; set; }
        [XmlElement(ElementName = "CaucusShortName")]
        public string CaucusShortName { get; set; }
        [XmlElement(ElementName = "FromDateTime")]
        public DateTime FromDateTime { get; set; }
        [XmlElement(ElementName = "ToDateTime")]
        public DateTime? ToDateTime { get; set; }
        // This property is not provided as part of the xml data for the members endpoint.
        // It must be manually parsed from the html
        public int PersonId { get; set; }
    }
}
