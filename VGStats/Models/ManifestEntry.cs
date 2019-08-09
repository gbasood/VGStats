using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace VGStats.Models
{

    /// <summary>
    /// Manifest entry logs. Contains character name, player key and assignment as defined at the end of a round.
    /// </summary>
    public class ManifestEntry
	{
		// I'd want to do something less dependent on an int ID normally but 2 billion records is good enough
		public int Id { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string Name { get; set; }
		public string Key { get; set; }
		public string Assignment { get; set; }
	}
}
