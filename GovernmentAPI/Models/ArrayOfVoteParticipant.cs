using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// Government API XML wrapper returned when loading from the membervote endpoint
    /// </summary>
    [XmlRoot(ElementName = "ArrayOfVoteParticipant")]
    public class ArrayOfVoteParticipant
    {
        [XmlElement(ElementName = "VoteParticipant")]
        public GovernmentMemberVote[] Participants { get; set; }
    }
}
