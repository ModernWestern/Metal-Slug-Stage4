using UnityEngine;
using B25.PoolSystem;

public class Loot : Reward
{
    public Loot(GameObject container)
    {
        Container = container;
        RewardType = PoolType.RocketAmmo;
    }
}
