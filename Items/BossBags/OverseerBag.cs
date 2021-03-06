using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class OverseerBag : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right Click to open");
		}


        public override void SetDefaults()
        {
			item.width = 20;
            item.height = 20;
            item.rare = -2;

            item.maxStack = 30;

			item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
		{
            player.QuickSpawnItem(mod.ItemType("EternityCharm"));
            string[] lootTable = { "Eternity", "SoulExpulsor", "EssenseTearer", "AeonRipper", };
            int loot = Main.rand.Next(lootTable.Length);
            int Randd = Main.rand.Next(18, 28);
            for (int I = 0; I < Randd; I++)
            {
                player.QuickSpawnItem(mod.ItemType("EternityEssence"));
            }
            int yikea = Main.rand.Next(30, 54);
            {
                for (int I = 0; I < yikea; I++)
                {
                    player.QuickSpawnItem(ItemID.GoldCoin);
                }
            }
            player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
