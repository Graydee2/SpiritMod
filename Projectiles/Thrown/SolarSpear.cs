using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Projectiles.Thrown
{
	public class SolarSpear : ModProjectile
	{
		private int Counter = 0;
		public override void SetDefaults()
		{
			projectile.name = "Solar Spear";
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 113;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.light = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.ThrowingKnife;
		}

		public override void AI()
		{
			Counter++;
			if (Counter % 15 == 1)
			{
				for (int i = 0; i < 2; ++i)
            {
                int randFire = Main.rand.Next(3);
                int newProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 
                    0, 4,
                    ProjectileID.GreekFire1 + randFire, projectile.damage, 0, projectile.owner);
                Main.projectile[newProj].hostile = false;
                Main.projectile[newProj].friendly = true;
            }
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileExtras.DrawAroundOrigin(projectile.whoAmI, lightColor);
			return false;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			 int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, 0, 0, mod.ProjectileType("SolarExplosion"), (int)(projectile.damage), 0, Main.myPlayer);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			return true;
		}
	}
}