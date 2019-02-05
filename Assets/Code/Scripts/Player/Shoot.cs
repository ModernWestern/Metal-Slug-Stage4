using UnityEngine;

public class Shoot : IBehaviour
{
    private IWeapon[] weapons;
    private Player player;

    private WeaponType currentWeapon = WeaponType.Pistol; // Default
    private int rocketLauncherAmmo;

    public void Init(object obj)
    {
        player = obj as Player;
    }

    public Shoot(IWeapon[] weapons)
    {
        this.weapons = weapons;

        Globals.Tools.Event.Subscribe(EventType.OnStart, SetFirePoint);
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Shooting);
        Globals.Tools.Event.Subscribe(EventType.OnSwitchWeapon, SwitchWeapon);
    }

    private void SetFirePoint()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Init(player);
        }
    }

    private void Reload() // Reload all weapons each time player pick some ammo
    {
        rocketLauncherAmmo = 30;
    }

    private void SwitchWeapon(object obj)
    {
        currentWeapon = (WeaponType)((int?)obj).Value;
        Reload();
    }
    
    private void Shooting() // Execute the current weapon Shoot method 
    {
        if (GameInputs.SingleShoot && player.Shoot)
        {
            if (currentWeapon == WeaponType.Pistol) weapons[(int)currentWeapon].Shoot();

            if (currentWeapon == WeaponType.RocketLauncher && rocketLauncherAmmo > 0)
            {
                weapons[(int)currentWeapon].Shoot();
                rocketLauncherAmmo--;
            }
            else currentWeapon = WeaponType.Pistol;
        }
    }
}
