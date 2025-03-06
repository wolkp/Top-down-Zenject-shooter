public interface IWeapon
{
    void Shoot(IProjectile projectile);
    bool CanShoot();
}