using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
<<<<<<< HEAD
    public class PollinationPoison : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Pollination Poison");
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 8;

            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 107);      
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;		
            }
        }
    }
=======
	public class PollinationPoison : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Pollination Poison");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 7;

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 107);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
>>>>>>> fa4f832c99c4926d56e19517ec763ad973d66f1b
}