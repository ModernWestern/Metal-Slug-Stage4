using B25.PoolSystem;

public class Pick : IBehaviour
{
    private WeaponType? ammoItem;

    public Pick()
    {
        Globals.Tools.Event.Subscribe(EventType.OnItemPickUp, PickUp);
    }

    public void Init(object obj)
    {
        return; // Awful
    }

    private void PickUp(object obj)
    {
        var item = obj as RewardItem?;

        ammoItem = null;

        switch(item.Value.poolType)
        {
            case PoolType.RocketAmmo:
                ammoItem = WeaponType.RocketLauncher;
                break;
        }

        Globals.Tools.Event.Fire(EventType.OnSwitchWeapon, (int?)ammoItem.Value); // Switch weapon from the class Shoot
        Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.PickUp); // Fire a sfx
        Globals.Tools.ObjectPooling.Drop(item.Value.poolType, item.Value.item); // Drop RocketAmmo prefab to the pool
    }
}
