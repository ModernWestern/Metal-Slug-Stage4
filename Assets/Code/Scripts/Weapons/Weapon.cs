using UnityEngine;
using B25.PoolSystem;

public abstract class Weapon
{
    // The next getset are modiefied by their heirs
    protected GameObject FirePoint { get; set; }
    protected int ProjectileVelocity { get; set; }
    protected PoolType ProjectileType { get; set; }
    protected float FireRate { get; set; }
    protected bool Cooled { get; private set; }
    //protected bool IsJumping {private get; set; }

    private float coolDown;
    private bool bang;

    private GameObject projectile;
    private Ray ray;

    protected Weapon()
    {
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Cooler);
    }

    private void Cooler()
    {
        if (GameInputs.SingleShoot && !bang)
        {
            bang = true;
            Cooled = true;
            coolDown = FireRate;
        }
        else Cooled = false;
        if (coolDown > 0) coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            bang = false;
            coolDown = 0;
        }
    }

    protected void Shoot() // All logic
    {
        projectile = Globals.Tools.ObjectPooling.Grab(ProjectileType); // Spawn a projectile with a Projectile Script attached to it
        projectile.transform.position = FirePoint.transform.position;
        projectile.transform.localRotation = FirePoint.transform.rotation;
        
        ray.origin = FirePoint.transform.position;
        ray.direction = FirePoint.transform.right;

        //if (GameInputs.Up) ray.direction = FirePoint.transform.up;
        //else if (GameInputs.Down && IsJumping) ray.direction = -FirePoint.transform.up;
        //else ray.direction = FirePoint.transform.right;

        if (Physics.Raycast(ray, out RaycastHit hit, Globals.Generics.WorldLength, Globals.Layers.ProjectileDirection))
        {
            projectile.GetComponent<Projectile>().HitPoint = hit.point; // Tell the bullet where needs to go
            projectile.GetComponent<Projectile>().ProjectilVelocity = ProjectileVelocity; // Set bullet velocity
            projectile.GetComponent<Projectile>().ProjectileType = ProjectileType; // Set sort of bullet
        }
    }
}
