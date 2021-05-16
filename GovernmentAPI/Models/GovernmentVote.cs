using System;
using System.Xml.Serialization;

namespace ParliamentApp.GovernmentAPI.Models
{
    /// <summary>
    /// Vote model from - https://www.ourcommons.ca/Members/en/votes/
    /// </summary>
    [XmlRoot(ElementName = "Vote")]
    public class GovernmentVote
    {
        [XmlElement(ElementName = "ParliamentNumber")]
        public int ParliamentNumber { get; set; }
        [XmlElement(ElementName = "SessionNumber")]
        public int SessionNumber { get; set; }
        [XmlElement(ElementName = "DecisionEventDateTime")]
        public DateTime DecisionEventDateTime { get; set; }
        [XmlElement(ElementName = "DecisionDivisionNumber")]
        public int DecisionDivisionNumber { get; set; }
        [XmlElement(ElementName = "DecisionDivisionSubject")]
        public string DecisionDivisionSubject { get; set; }
        [XmlElement(ElementName = "DecisionResultName")]
        public string DecisionResultName { get; set; }
        [XmlElement(ElementName = "DecisionDivisionNumberOfYeas")]
        public int DecisionDivisionNumberOfYeas { get; set; }
        [XmlElement(ElementName = "DecisionDivisionNumberOfNays")]
        public int DecisionDivisionNumberOfNays { get; set; }
        [XmlElement(ElementName = "DecisionDivisionNumberOfPaired")]
        public int DecisionDivisionNumberOfPaired { get; set; }
        [XmlElement(ElementName = "DecisionDivisionDocumentTypeName")]
        public string DecisionDivisionDocumentTypeName { get; set; }
        [XmlElement(ElementName = "DecisionDivisionDocumentTypeId")]
        public int DecisionDivisionDocumentTypeId { get; set; }
        [XmlElement(ElementName = "BillNumberCode")]
        public string BillNumberCode { get; set; } // C-XX
    }
}
