using UnityEngine;

public class Move : IBehaviour
{
    private readonly Vector3 Forward = new Vector3(0, 0, 0);
    private readonly Vector3 Back = new Vector3(0, 180, 0);
    private readonly Vector3 GetFree = new Vector3(.005f, 0, 0);
    private readonly float MinSpeed;
    private readonly float MaxSpeed;

    private Player player;

    public Move(float minSpeed, float maxSpeed)
    {
        MinSpeed = minSpeed;
        MaxSpeed = maxSpeed;

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Moving);
    }
    
    public void Init(object obj)
    {
        player = obj as Player;
    }
    
    void Moving()
    {
        var screenPosition = Globals.Generics.MainCamera.WorldToScreenPoint(player.Entity.transform.position);
        screenPosition.x = Mathf.Clamp01(screenPosition.x);
        
        if (player.Entity)
        {
            if (screenPosition.x > .05f)
            {
                if (player.Grounded) // Ground
                {
                    if (GameInputs.Forward)
                    {
                        player.Entity.transform.position += Globals.Vectors.Vector3Roght * Time.deltaTime * (GameInputs.Duck ? MinSpeed : MaxSpeed);
                        player.Entity.transform.rotation = Quaternion.Euler(Forward);
                    }
                    if (GameInputs.Back)
                    {
                        player.Entity.transform.position += Globals.Vectors.Vector3Left * Time.deltaTime * (GameInputs.Duck ? MinSpeed : MaxSpeed);
                        player.Entity.transform.rotation = Quaternion.Euler(Back);
                    }
                }
                else // Air
                {
                    if (GameInputs.Forward)
                    {
                        player.Entity.transform.position += Globals.Vectors.Vector3Roght * Time.deltaTime * MaxSpeed;
                        player.Entity.transform.rotation = Quaternion.Euler(Forward);
                    }
                    if (GameInputs.Back)
                    {
                        player.Entity.transform.position += Globals.Vectors.Vector3Left * Time.deltaTime * MaxSpeed;
                        player.Entity.transform.rotation = Quaternion.Euler(Back);
                    }
                }
            }
            else player.Entity.transform.position = player.Entity.transform.position + GetFree; // Get Free (Player get stuck in camera bounds)
        }
        else Globals.Tools.Event.Unsubscribe(EventType.OnUpdate, Moving);
    }

    public IBehaviour Clone()
    {
        return new Move(MinSpeed, MaxSpeed);
    }
}
