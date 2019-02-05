
using UnityEngine;
using B25.PoolSystem;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private readonly WaitForSeconds RecyclingTime = new WaitForSeconds(3);

    // Set the next getset from Weapon class

    public Vector3 HitPoint { private get; set; }
    public int ProjectilVelocity { private get; set; }
    public PoolType ProjectileType { private get; set; } // Store the Type to drop to the pool

    private Ray ray;

    private void OnEnable()
    {
        HitPoint = Globals.Vectors.Vector3Zero;
        StartCoroutine(SafeRecycling());
    }

    IEnumerator SafeRecycling()
    {
        yield return RecyclingTime;
        Globals.Tools.ObjectPooling.Drop(ProjectileType, gameObject); // If projectile is living to much drop to the pool
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, HitPoint, Time.deltaTime * ProjectilVelocity);
        BulletCollision();
    }

    private void BulletCollision()
    {
        ray.origin = transform.position;
        ray.direction = transform.right;

        if (Physics.SphereCast(ray, .1f, out RaycastHit hit, .5f, Globals.Layers.Enemy | Globals.Layers.Loot))
        {
            switch (hit.transform.gameObject.tag)
            {
                case Globals.Tags.Enemy:
                    Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.Death);
                    break;
                case Globals.Tags.Loot:
                    Globals.Tools.Event.Fire(EventType.OnGetReward, hit.transform.gameObject); // Raise OnGetReward from Reward Class
                    break;
            }
            hit.transform.gameObject.SetActive(false); // Deactivate the impacted GameObject

            Globals.Tools.ObjectPooling.Drop(ProjectileType, gameObject); // If projectile impact drop to the pool
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(ray.origin + ray.direction * .5f, .1f);
    //}
}