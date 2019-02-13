using UnityEngine;

public class Stab : IBehaviour
{
    private Player player;

    public Stab()
    {
        Globals.Tools.Event.Subscribe(EventType.OnNearbyEnemy, StabEnemy);
    }

    public void Init(object obj)
    {
        player = obj as Player;
    }

    private void StabEnemy(object obj)
    {
        var enemy = obj as GameObject;

        if (GameInputs.Stab && player.Stab)
        {
            enemy.SetActive(false);
            Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.Stab);
        }
    }

    public IBehaviour Clone()
    {
        return new Stab();
    }
}
