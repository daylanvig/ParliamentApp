using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// Government API XML wrapper returned when loading from the membervote endpoint
    /// </summary>
    [XmlRoot(ElementName = "ArrayOfVote")]
    public class ArrayOfVote
    {
        [XmlElement(ElementName = "Vote")]
        public GovernmentVote[] Votes { get; set; }
    }
}
