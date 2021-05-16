using ParliamentApp.Models.Common;

namespace ParliamentApp.Models
{
    public class MemberVote : Entity
    {
        #region OneToMany (Child)
        public int VoteId { get; set; }
        public Vote Vote { get; set; }
        #endregion
        #region OneToOne
        public int MemberOfParliamentId { get; set; }
        public MemberOfParliament MemberOfParliament { get; set; }
        #endregion
        #region Attributes
        public VoteDecision VoteValue { get; set; }
        #endregion
    }
}
