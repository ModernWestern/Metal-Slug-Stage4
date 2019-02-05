using UnityEngine;
using B25.PoolSystem;

public class OffScreenRecycling : MonoBehaviour
{
    public bool isChild;
    public PoolType poolType;

    private void OnBecameInvisible()
    {
        if (isChild)
        {
            var parent = gameObject.transform.parent.transform.gameObject;
            Globals.Tools.ObjectPooling.Drop(poolType, parent);
        }
        else Globals.Tools.ObjectPooling.Drop(poolType, gameObject);
    }
}