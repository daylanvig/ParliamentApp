using ParliamentApp.Models.Common;
using System;
using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// A member vote, as provided by government of canada api
    /// </summary>
    [XmlRoot(ElementName = "VoteParticipant")]
    public class GovernmentMemberVote
    {
        [XmlElement(ElementName = "ParliamentNumber")]
        public string ParliamentNumber { get; set; }
        [XmlElement(ElementName = "SessionNumber")]
        public string SessionNumber { get; set; }
        [XmlElement(ElementName = "DecisionEventDateTime")]
        public DateTime DecisionEventDateTime { get; set; }
        [XmlElement(ElementName = "DecisionDivisionNumber")]
        public string DecisionDivisionNumber { get; set; }
        [XmlElement(ElementName = "PersonShortSalutation")]
        public string PersonShortSalutation { get; set; }
        [XmlElement(ElementName = "ConstituencyName")]
        public string ConstituencyName { get; set; }
        [XmlElement(ElementName = "VoteValueName")]
        public string VoteValueName { get; set; }
        [XmlElement(ElementName = "PersonOfficialFirstName")]
        public string PersonOfficialFirstName { get; set; }
        [XmlElement(ElementName = "PersonOfficialLastName")]
        public string PersonOfficialLastName { get; set; }
        [XmlElement(ElementName = "ConstituencyProvinceTerritoryName")]
        public Province ConstituencyProvinceTerritoryName { get; set; }
        [XmlElement(ElementName = "CaucusShortName")]
        public string CaucusShortName { get; set; }
        [XmlElement(ElementName = "IsVoteYea")]
        public bool IsVoteYea { get; set; }
        [XmlElement(ElementName = "IsVoteNay")]
        public bool IsVoteNay { get; set; }
        [XmlElement(ElementName = "IsVotePaired")]
        public bool IsVotePaired { get; set; }
        [XmlElement(ElementName = "DecisionResultName")]
        public string DecisionResultName { get; set; }
        [XmlElement(ElementName = "PersonId")]
        public int PersonId { get; set; }
    }
}
