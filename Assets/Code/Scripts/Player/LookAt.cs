using UnityEngine;
using B25.PoolSystem;

public class LookAt : IBehaviour
{
    private Player player;
    private Ray ray;

    public LookAt()
    {
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Look);
    }

    public void Init(object obj)
    {
        player = obj as Player;
    }

    private void Look()
    {
        ray.origin = player.Body.transform.position + Globals.Vectors.Vector3Up;
        ray.direction = player.Body.transform.right;

        if (player.Entity)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, .75f, Globals.Layers.Enemy | Globals.Layers.Reward))
            {
                switch (hit.transform.gameObject.tag)
                {
                    case Globals.Tags.Enemy:
                        Enemy(hit);
                        break;
                    case Globals.Tags.RocketAmmo:
                        DropRocketAmmo(hit);
                        break;
                }
            }
            else
            {
                player.Shoot = true;
                player.Stab = false;
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * .5f, Color.yellow);
    }

    private void Enemy(RaycastHit hit)
    {
        player.Stab = true;
        player.Shoot = false;
        Globals.Tools.Event.Fire(EventType.OnNearbyEnemy, hit.transform.gameObject);
    }

    private void DropRocketAmmo(RaycastHit hit)
    {
        RewardItem? Item = new RewardItem(hit.transform.gameObject, PoolType.RocketAmmo);
        Globals.Tools.Event.Fire(EventType.OnItemPickUp, Item);
    }
}
