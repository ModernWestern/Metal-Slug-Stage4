using UnityEngine;

public class Player
{
    public GameObject Entity { get; private set; }
    public MonoBehaviour Mono { get; private set; }

    public bool Grounded { get; set; }
    public bool Stab { get; set; }
    public bool Shoot { get; set; }
    public bool Duck { get; set; }

    public GameObject Body { get; private set; }
    public GameObject Gun { get; private set; }
    public GameObject FirePoint { get; private set; }

    public Player(GameObject entity, IBehaviour[] behaviours, MonoBehaviour mono)
    {
        Entity = entity;
        Mono = mono;

        Body = Entity.transform.GetChild(0).gameObject;
        Gun = Body.transform.GetChild(0).gameObject;
        FirePoint = Gun.transform.GetChild(0).gameObject;
        Shoot = true;

        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].Init(this);
        }
    }
}