using UnityEngine;

public class Enemy : ISpawnable
{
    private IBehaviour[] behaviours;
    
    public Enemy(IBehaviour[] behaviours)
    {
        this.behaviours = behaviours;
    }

    public void Init(object obj)
    {
        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].Init(obj as GameObject);
        }
    }
}
