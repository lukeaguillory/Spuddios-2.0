namespace Assets.Scripts.Weapons
{
    public class RangedWeapon : Weapon
    {
        private ProjectileType projectileType;
        void Update()
        {
            //check when to shoot based on rate, then shoot
        }

        public void Shoot()
        {
            var projectile = Repository.FirstOrDefault<Projectile>(projectileType.ToString());
            //instantiate projectile
            //set projectile properties based on modifiers players has
        }

        public void SetProjectileType(ProjectileType projectileType)
        {
            this.projectileType = projectileType;
        }
    }
}
