using ParliamentApp.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ParliamentApp.Models
{
    /// <summary>
    /// Vote model from - https://www.ourcommons.ca/Members/en/votes/
    /// </summary>
    public class Vote : Entity
    {
        #region OneToMany (Child)
        public int ParliamentPeriodId { get; set; }
        public ParliamentPeriod ParliamentPeriod { get; set; }
        #endregion
        #region OneToMany (Parent)
        public IEnumerable<MemberVote> MemberVotes { get; set; }
        #endregion
        #region Attributes
        public string BillNumberCode { get; set; } // C-XX
        public DateTimeOffset DecisionEventDateTime { get; set; }
        public int DecisionDivisionNumber { get; set; }
        public string DecisionDivisionSubject { get; set; }
        public string DecisionResultName { get; set; }
        public int DecisionDivisionNumberOfYeas { get; set; }
        public int DecisionDivisionNumberOfNays { get; set; }
        public int DecisionDivisionNumberOfPaired { get; set; }
        public string DecisionDivisionDocumentTypeName { get; set; }
        public int DecisionDivisionDocumentTypeId { get; set; }
        #endregion

    }
}
