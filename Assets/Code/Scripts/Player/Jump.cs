using UnityEngine;

public class Jump : IBehaviour
{
    private readonly float JumpForce;

    private Player player;
    private Rigidbody rigidBody;

    private bool jumpRequest;

    public Jump(float jumpForce)
    {
        JumpForce = jumpForce;

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Inputs);
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Jumping);
    }
    
    public void Init(object obj)
    {
        player = obj as Player;
        rigidBody = player.Body.GetComponent<Rigidbody>();
    }
    
    private void Inputs()
    {
        jumpRequest = (GameInputs.Jump && !player.Duck) ? true : false;
    }

    // FixedUpdate = Jumping Artifacts

    private void Jumping()
    {
        if (player.Entity)
        {
            if (player.Grounded)
            {
                if (jumpRequest)
                {
                    rigidBody.AddForce(Globals.Vectors.Vector3Up * JumpForce, ForceMode.Impulse);
                    jumpRequest = false;
                }
            }
        }
        else
        {
            Globals.Tools.Event.Unsubscribe(EventType.OnUpdate, Inputs);
            Globals.Tools.Event.Unsubscribe(EventType.OnUpdate, Jumping);
        }
    }

    public IBehaviour Clone()
    {
        return new Jump(JumpForce);
    }
}
