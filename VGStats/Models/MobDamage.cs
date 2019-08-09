using Microsoft.EntityFrameworkCore;

namespace VGStats.Models
{
    [Owned]
    public class MobDamage
	{
		public int DamageBrute { get; set; }
		public int DamageFire { get; set; }
		public int DamageToxin { get; set; }
		public int DamageOxygen { get; set; }
		public int DamageClone { get; set; }
		public int DamageBrain { get; set; }
	}
}
