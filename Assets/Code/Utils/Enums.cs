public enum EventType
{
    /// <summary>
    /// Use MonoBehaviour Start
    /// </summary>
    OnStart,
    /// <summary>
    /// Use Monobehaviour Update
    /// </summary>
    OnUpdate,
    /// <summary>
    /// Use MonoBehaviour LateUpdate
    /// </summary>
    OnLateUpdate,
    /// <summary>
    /// Use MonoBehaviour FixedUpdate
    /// </summary>
    OnFixedUpdate,
    /// <summary>
    /// Set a reward
    /// </summary>
    OnGetReward,
    /// <summary>
    /// Insert WeaponType index as nullable
    /// </summary>
    OnSwitchWeapon,
    /// <summary>
    /// Insert a SoundEffect from Globals
    /// </summary>
    OnSFX,
    /// <summary>
    /// Raise only in LookAt class
    /// </summary>
    OnItemPickUp,
    /// <summary>
    /// Return the nearest enemy
    /// </summary>
    OnNearbyEnemy
}

public enum WeaponType
{
    Pistol,
    RocketLauncher,
    HeaveMachineGun,
    Shotgun,
    Grenade
}