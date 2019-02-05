using UnityEngine;

public class GrowndCheck : IBehaviour
{
    private Player player;
    private Ray ray;

    public GrowndCheck()
    {
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, GroundCheck);
    }

    public void Init(object obj)
    {
        player = obj as Player;
    }

    private void GroundCheck()
    {
        ray.origin = player.Body.transform.position + Globals.Vectors.Vector3Up;
        ray.direction = Globals.Vectors.Vector3Down;

        if (player.Entity) player.Grounded = Physics.Raycast(ray, 1.125f, Globals.Layers.Ground) ? true : false;
        else Globals.Tools.Event.Unsubscribe(EventType.OnUpdate, GroundCheck);
    }
}
