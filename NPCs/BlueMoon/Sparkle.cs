using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class Sparkle : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparkle");
        }
        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 34;
            npc.damage = 30;
            npc.defense = 0;
            npc.lifeMax = 10;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            //npc.value = 1000f;
			 npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.25f;

        }
        
       /* public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
            }
        }*/
		public override bool CheckDead()
		{
			Vector2 center = npc.Center;
			Terraria.Projectile.NewProjectile(center.X, center.Y, 0f, 0f, mod.ProjectileType("UnstableWisp_Explosion"), 30, 0f, Main.myPlayer);
			return true;
		}
		
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.40f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
		public override bool PreAI()
		  {
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();
            direction.Normalize();
            npc.velocity *= 0.98f;
            int dust2 = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[dust2].noGravity = true;
            if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) >= 7f)
                {
                int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
                dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
            }
            if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 1.5f)
            {
                if (Main.rand.Next(25) == 1)
                {
                    direction.X = direction.X * Main.rand.Next(15,18);
                    direction.Y = direction.Y * Main.rand.Next(15,18);
                    npc.velocity.X = direction.X;
                    npc.velocity.Y = direction.Y;
					
                }
            }
            return false;

        }
       public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }		
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			Vector2 center = npc.Center;
			Terraria.Projectile.NewProjectile(center.X, center.Y, 0f, 0f, mod.ProjectileType("UnstableWisp_Explosion"), 40, 0f, Main.myPlayer);
			npc.life = 0;
		}
        public override void NPCLoot()
        {
           /* if (Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ToxicExtract"));
            }*/
        }
        
    }
}