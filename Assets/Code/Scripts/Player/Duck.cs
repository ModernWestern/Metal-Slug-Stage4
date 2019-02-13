using UnityEngine;

public class Duck : IBehaviour
{
    private readonly Vector3 STAND = new Vector3(1, 1, 1);
    private readonly Vector3 DUCK = new Vector3(1, .6f, 1);

    private Player player;
    
    public Duck()
    {
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Ducking);
    }
    
    public void Init(object obj)
    {
        player = obj as Player;
    }

    private void Ducking()
    {
        if (player.Entity)
        {
            if (player.Grounded)
            {
                if (GameInputs.Duck)
                {
                    player.Entity.transform.localScale = DUCK;
                    player.Duck = true;
                }
                else
                {
                    player.Entity.transform.localScale = STAND;
                    player.Duck = false;
                }
            }
            else player.Entity.transform.localScale = STAND;
        }
        else Globals.Tools.Event.Unsubscribe(EventType.OnUpdate, Ducking);
    }

    public IBehaviour Clone()
    {
        return new Duck();
    }
}