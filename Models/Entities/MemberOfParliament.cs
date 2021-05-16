using ParliamentApp.Models.Common;
using System;

namespace ParliamentApp.Models
{
	/// <summary>
	/// Model to represent a member of parliament
	/// </summary>
    public class MemberOfParliament : Entity
	{
		/// <summary>
		/// ParliamentPersonId - the unique identifier given by the government of canada. 
		/// </summary>
		public int ParliamentPersonId { get; set; }
		public string PersonShortHonorific { get; set; }
		public string PersonOfficialFirstName { get; set; }
		public string PersonOfficialLastName { get; set; }
		public string ConstituencyName { get; set; }
		public Province ConstituencyProvinceTerritoryName { get; set; }
		public string CaucusShortName { get; set; }
		public DateTimeOffset FromDateTime { get; set; }
		public DateTimeOffset? ToDateTime { get; set; }
	}
}
