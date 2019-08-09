using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class UplinkBuy
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
		public string BuyerRole { get; set; }
		// Either one or the other will be set, not both.
		// TODO maybe make this not stupid huh?
		public string BundlePath { get; set; }
		public string ItemPath { get; set; }
		/// <summary>
		/// Uplink cost can vary depending on the purchaser's job.
		/// </summary>
		public int ItemCost { get; set; }
	}
}
