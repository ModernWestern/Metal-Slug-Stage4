using B25.PoolSystem;
using UnityEngine;

public struct WeaponFeature
{
    public PoolType projectile;
    public int projectileVelocity;
    public float fireRate;
    public int damageAmount;

    public WeaponFeature(PoolType projectile, int projectileVelocity, float fireRate, int damageAmount)
    {
        this.projectile = projectile;
        this.projectileVelocity = projectileVelocity;
        this.fireRate = fireRate;
        this.damageAmount = damageAmount;
    }
}

public struct SoundEffect
{
    public int clip;
    public float volume;
    public float pitch;
    
    public SoundEffect(int clip, float volume, float pitch)
    {
        this.clip = clip;
        this.volume = volume;
        this.pitch = pitch;
    }
}

public struct RewardItem
{
    public GameObject item;
    public PoolType poolType;

    public RewardItem(GameObject item, PoolType poolType)
    {
        this.item = item;
        this.poolType = poolType;
    }
}