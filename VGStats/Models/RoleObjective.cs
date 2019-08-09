using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class RoleObjective
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }

		/// <summary>
		/// Typepath of the objective.
		/// </summary>
		[Required]
		public string ObjectiveType { get; set; }
		[Required]
		public string ObjectiveDescription { get; set; }
		[Required]
		public bool ObjectiveSuccessful { get; set; }
	}
}
