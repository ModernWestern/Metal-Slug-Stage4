using UnityEngine;
using System;
using System.Linq;
using B25.PoolSystem;

public class EnemySapwner
{
    private const int SPAWN_DISTANCE = 220;

    private GameObject entity;
    private Squad[] squads;

    private int switchIndex;

    Func<Vector3, Vector3, float> Distance = (a, b) => (a - b).sqrMagnitude;
    Func<Vector3[], Vector3> SmallerPosition = p => p.OrderBy(vector => vector.sqrMagnitude).First();

    public EnemySapwner(GameObject entity, Squad[] squads)
    {
        this.entity = entity;
        this.squads = squads;

        switchIndex = 0;

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, DynamicSpawn);
    }

    private void SquadSpawner(Vector3 playerPosition, int index)
    {
        if (Distance(playerPosition, SmallerPosition(squads[index].positions)) < SPAWN_DISTANCE)
        {
            for (int i = 0; i < squads[index].squad.Length; i++)
            {
                var enemy = Globals.Tools.ObjectPooling.Grab(PoolType.Enemy);
                enemy.transform.position = squads[index].positions[i];
                squads[index].squad[i].Init(enemy);
            }
            switchIndex++;
        }
    }

    private void DynamicSpawn()
    {
        switch (switchIndex)
        {
            case 0:
                SquadSpawner(entity.transform.position, 0);
                break;
            case 1:
                SquadSpawner(entity.transform.position, 1);
                break;
        }
    }
}
