using Microsoft.EntityFrameworkCore;

namespace VGStats.Models
{
    [Owned]
    public class Location
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }
	}
}
