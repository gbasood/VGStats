using System;
using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class PopulationSnapshot
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public int PopCount { get; set; }
		public DateTime Time { get; set; }
	}
}
