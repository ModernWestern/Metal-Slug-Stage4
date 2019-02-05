using UnityEngine;

public class Pistol : Weapon, IWeapon
{
    public Pistol(WeaponFeature feature)
    {
        ProjectileType = feature.projectile;
        ProjectileVelocity = feature.projectileVelocity;
        FireRate = feature.fireRate;
    }

    public void Init(object obj)
    {
        var player = obj as Player;
        FirePoint = player.FirePoint;
        //IsJumping = !player.Grounded; // If Grounded is false, it's jumping
    }

    public new void Shoot()
    {
        if (Cooled)
        {
            base.Shoot();
            Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.PistolShot);
        }
    }
}
