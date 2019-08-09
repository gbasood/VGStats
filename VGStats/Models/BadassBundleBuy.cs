using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class BadassBundleBuy
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
		/// <summary>
		/// Was the buyer of the uplink item a traitor?
		/// </summary>
		public string BuyerRoleType { get; set; }

		public List<BadassBundleItem> Items { get; set; }
	}
}
