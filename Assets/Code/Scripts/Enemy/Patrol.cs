using UnityEngine;

public class Patrol : IBehaviour
{
    private GameObject enemy;

    private float randomVel;

    public Patrol()
    {
        randomVel = Random.value * 2;
    }
    
    public void Init(object obj)
    {
        enemy = obj as GameObject;
        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Patrolling);
    }

    private void Patrolling()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, Globals.Vectors.Vector3Zero, randomVel * Time.deltaTime);
    }

    public IBehaviour Clone()
    {
        return new Patrol();
    }
}