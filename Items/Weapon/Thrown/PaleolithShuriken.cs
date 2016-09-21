﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class PaleolithShuriken : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Paleolith Shuriken";
            item.width = 18;
            item.height = 20;
            item.toolTip = "???";
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 2;
            item.maxStack = 999;

            item.crit = 4;
            item.damage = 55;
            item.knockBack = 0;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 14;
            
            item.thrown = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("PaleolithShuriken");
            item.shootSpeed = 11;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence", 5);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}