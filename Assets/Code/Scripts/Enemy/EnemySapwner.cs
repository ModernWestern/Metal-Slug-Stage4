using UnityEngine;
using System.Linq;
using System;
using B25.PoolSystem;

public class EnemySapwner
{
    private const int SPAWN_DISTANCE = 220;

    private GameObject entity;
    
    private int switchIndex;
    private Vector3[] squad_0;
    private Vector3[] squad_1;
    private Vector3[] squad_2;

    Func<float, Vector3> SquadPosition = d => new Vector3(d, 0, UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1);
    Func<Vector3, Vector3, float> Distance = (a, b) => (a - b).sqrMagnitude;
    Func<Vector3[], Vector3> SmallerPosition = p => p.OrderBy(vector => vector.sqrMagnitude).First();

    public EnemySapwner(GameObject entity)
    {
        this.entity = entity;

        squad_0 = new Vector3[5];
        squad_0[0] = SquadPosition(30);
        squad_0[1] = SquadPosition(35);
        squad_0[2] = SquadPosition(40);
        squad_0[3] = SquadPosition(45);
        squad_0[4] = SquadPosition(55);

        squad_1 = new Vector3[5];
        squad_1[0] = SquadPosition(65);
        squad_1[1] = SquadPosition(70);
        squad_1[2] = SquadPosition(75);
        squad_1[3] = SquadPosition(85);
        squad_1[4] = SquadPosition(95);

        squad_2 = new Vector3[5];
        squad_2[0] = SquadPosition(100);
        squad_2[1] = SquadPosition(105);
        squad_2[2] = SquadPosition(115);
        squad_2[3] = SquadPosition(125);
        squad_2[4] = SquadPosition(130);

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, DynamicSpawn);
    }

    private void SquadSpawner(Vector3 entityPosition, Vector3[] squad)
    {
        if (Distance(entityPosition, SmallerPosition(squad)) < SPAWN_DISTANCE)
        {
            for (int i = 0; i < squad.Length; i++)
            {
                var enemy = Globals.Tools.ObjectPooling.Grab(PoolType.Enemy);
                enemy.transform.position = squad[i];
            }
            switchIndex++;
        }
    }

    private void DynamicSpawn()
    {
        switch (switchIndex)
        {
            case 0:
                SquadSpawner(entity.transform.position, squad_0);
                break;
            case 1:
                SquadSpawner(entity.transform.position, squad_1);
                break;
            case 2:
                SquadSpawner(entity.transform.position, squad_2);
                break;
        }
    }
}
