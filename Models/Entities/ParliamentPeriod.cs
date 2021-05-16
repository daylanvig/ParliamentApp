using System;
using System.Collections.Generic;

namespace ParliamentApp.Models.Entities
{
    /// <summary>
    /// A ParliamentPeriod represents a single session within a parliament
    /// </summary>
    public class ParliamentPeriod : Entity
    {
        // parliamentnumber/session is unique index
        public int ParliamentNumber { get; set; }
        public int SessionNumber { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; } // null if ongoing
        public IEnumerable<Vote> Votes { get; set; }
        public IEnumerable<MemberOfParliament> MembersOfParliament { get; set; }
    }
}
