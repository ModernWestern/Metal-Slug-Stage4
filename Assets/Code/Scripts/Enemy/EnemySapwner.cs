using UnityEngine;
using System.Linq;
using B25.PoolSystem;
public class EnemySapwner
{
    private GameObject entity;
    private Vector3[] positions;
    private bool isSpawned;

    public EnemySapwner(GameObject entity)
    {
        this.entity = entity;

        positions = new Vector3[4];
        positions[0] = new Vector3(30, 0, 1);
        positions[1] = new Vector3(35, 0, -1);
        positions[2] = new Vector3(40, 0, 1);
        positions[3] = new Vector3(45, 0, -1);

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, DynamicSpawn);
    }

    private Vector3 SmallerPosition(Vector3[] positions)
    {
        return positions.OrderBy(vector => vector.sqrMagnitude).First();
    }

    private void DynamicSpawn()
    {
        var v = entity.transform.position - SmallerPosition(positions);

        if (v.sqrMagnitude < 220)
        {
            if (!isSpawned)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    var enemy = Globals.Tools.ObjectPooling.Grab(PoolType.Enemy);
                    enemy.transform.position = positions[i];
                    isSpawned = true;
                }
            }
        }
    }
}
