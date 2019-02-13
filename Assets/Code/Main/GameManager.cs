using UnityEngine;
using B25.PoolSystem;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Pool poolData;
    public GameObject lootsContainer;
    public AudioClip[] clips;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -50, 0); // Cartoony Gravity
    }

    private void Start()
    {
        #region Audio

        new AudioSystem(clips, this);
        Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.MissionStart); // SFX
        #endregion

        var player = Globals.Tools.ObjectPooling.Grab(PoolType.Player);

        #region Camera

        new CameraFollow(player, 2);
        #endregion
        
        #region Player

        var pistol = new WeaponFeature(PoolType.Bullet, 20, .1f, 1);
        var rocket = new WeaponFeature(PoolType.Rocket, 15, .3f, 5);

        var weapons = new IWeapon[2];
        weapons[(int)WeaponType.Pistol] = new Pistol(pistol);
        weapons[(int)WeaponType.RocketLauncher] = new RocketLauncher(rocket);

        var playerBehaviours = new IBehaviour[8];
        playerBehaviours[0] = new GrowndCheck();
        playerBehaviours[1] = new LookAt();
        playerBehaviours[2] = new Move(2,4);
        playerBehaviours[3] = new Duck();
        playerBehaviours[4] = new Jump(18);
        playerBehaviours[5] = new Shoot(weapons);
        playerBehaviours[6] = new Stab();
        playerBehaviours[7] = new Pick();

        new Player(player, playerBehaviours);
        #endregion

        #region Rewards

        new Loot(lootsContainer);
        #endregion

        #region Enemies
        
        var enemyBehaviours = new IBehaviour[1];
        enemyBehaviours[0] = new Patrol();

        #region How to Copy

        //Func<List<IBehaviour>, IBehaviour[]> Copy = b => b.Clone() as IBehaviour[]; // Shallow Copy

        //var original = enemyBehaviours.OfType<IBehaviour>().ToList(); // If you need to use Linq.ConvertAll() instead Linq.Select()
        //Func<List<IBehaviour>, IBehaviour[]> Copy = o => o.ConvertAll(c => c.Clone()).ToArray(); // Deep Copy
        #endregion

        Func<IBehaviour[], IBehaviour[]> Copy = b => b.Select(c => c.Clone()).ToArray(); // Deep Copy

        Func<float, Vector3> SquadPosition = d => new Vector3
        {
            x = d,
            y = 0,
            z = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1
        };

        #region Squad 0

        var squad_0_Capacity = 5;

        var squad_0 = new Enemy[squad_0_Capacity];
        squad_0[0] = new Enemy(Copy(enemyBehaviours));
        squad_0[1] = new Enemy(Copy(enemyBehaviours));
        squad_0[2] = new Enemy(Copy(enemyBehaviours));
        squad_0[3] = new Enemy(Copy(enemyBehaviours));
        squad_0[4] = new Enemy(Copy(enemyBehaviours));

        var squad_0_Positions = new Vector3[squad_0_Capacity];
        squad_0_Positions[0] = SquadPosition(30);
        squad_0_Positions[1] = SquadPosition(35);
        squad_0_Positions[2] = SquadPosition(40);
        squad_0_Positions[3] = SquadPosition(45);
        squad_0_Positions[4] = SquadPosition(55);
        #endregion

        #region Squad 1

        var squad_1_Capacity = 5;

        var squad_1 = new Enemy[squad_1_Capacity];
        squad_1[0] = new Enemy(Copy(enemyBehaviours));
        squad_1[1] = new Enemy(Copy(enemyBehaviours));
        squad_1[2] = new Enemy(Copy(enemyBehaviours));
        squad_1[3] = new Enemy(Copy(enemyBehaviours));
        squad_1[4] = new Enemy(Copy(enemyBehaviours));

        var squad_1_Positions = new Vector3[squad_1_Capacity];
        squad_1_Positions[0] = SquadPosition(70);
        squad_1_Positions[1] = SquadPosition(75);
        squad_1_Positions[2] = SquadPosition(85);
        squad_1_Positions[3] = SquadPosition(90);
        squad_1_Positions[4] = SquadPosition(100);
        #endregion

        var squads = new Squad[2];
        squads[0].squad = squad_0;
        squads[0].positions = squad_0_Positions;
        squads[1].squad = squad_1;
        squads[1].positions = squad_1_Positions;

        new EnemySapwner(player, squads);
        #endregion
    }
}