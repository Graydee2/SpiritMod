using System;
using Terraria.ModLoader;

namespace SpiritMod.YoYoOverload.Items
{
	public class Reap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dispatcher");
			Tooltip.SetDefault("Your foes meet their Dead End.");
		}


		public override void SetDefaults()
		{
			base.item.CloneDefaults(3278);
			base.item.damage = 71;
			base.item.value = 200000;
			base.item.rare = 7;
			base.item.knockBack = 6f;
			base.item.channel = true;
			base.item.useStyle = 5;
			base.item.useAnimation = 28;
			base.item.useTime = 25;
			base.item.shoot = base.mod.ProjectileType("ReapP");
		}
	}
}
