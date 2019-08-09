using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    /// <summary>
    /// A theft-based RoleObjective. Child of RoleObjectiveTargeted.
    /// </summary>
    public class TheftObjective : RoleObjectiveTargeted
	{
		[Required]
		public int RequiredAmount { get; set; }
		[Required]
		public int FoundAmount { get; set; }
	}
}
