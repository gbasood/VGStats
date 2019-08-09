using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class BadassBundleItem
	{
		public int Id { get; set; }
		[Required]
		public int BadassBundleId { get; set; }
		public BadassBundleBuy BadassBundle { get; set; }
		public string ItemPath { get; set; }
	}
}
