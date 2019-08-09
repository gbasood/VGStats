namespace VGStats.Models
{
    public class MalfModule
	{
		public int Id { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string ModuleBuyerKey { get; set; }
		public string ModuleName { get; set; }
	}
}
