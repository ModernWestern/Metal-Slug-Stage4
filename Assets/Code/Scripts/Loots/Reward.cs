using UnityEngine;
using B25.PoolSystem;

public abstract class Reward : IReward
{
    // Set the next getset from their heirs
    protected GameObject Container { private get; set; }
    protected PoolType RewardType { private get; set; }

    private GameObject[] entities;
    private int childCount;

    public Reward()
    {
        Globals.Tools.Event.Subscribe(EventType.OnStart, Init);
        Globals.Tools.Event.Subscribe(EventType.OnGetReward, GetReward);
    }
    
    //Set entities array with all the loots in the container
    private void Init()
    {
        childCount = Container.transform.childCount;

        if (childCount != 0)
        {
            entities = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                entities[i] = Container.transform.GetChild(i).gameObject;
            }
        }
    }

    // Raise this method every time a Projectile hit a loot
    public void GetReward(object obj)
    {
        for (int i = 0; i < childCount; i++)
        {
            if (entities[i] == obj as GameObject)
            {
                var reward = Globals.Tools.ObjectPooling.Grab(RewardType); // Get a Reward (Ammo)
                reward.transform.position = entities[i].transform.position; // Set Reward (Ammo) Position in the same impacted loot position
            }
        }
    }
}
