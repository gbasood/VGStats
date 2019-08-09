using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    /// <summary>
    /// A RoleObjective that targets a specific player or item(s).
    /// </summary>
    public class RoleObjectiveTargeted : RoleObjective
	{
		[Required]
		public string TargetName { get; set; }
	}
}
