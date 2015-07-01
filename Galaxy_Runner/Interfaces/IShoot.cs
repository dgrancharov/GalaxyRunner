using System;
using Galaxy_Runner.GameObjects.Items.Projectiles;

namespace Galaxy_Runner.Interfaces
{
	public interface IShoot
	{
        Projectile CreateProjectile();
	}
}

