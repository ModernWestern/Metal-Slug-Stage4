using UnityEngine;
using B25.PoolSystem;

public class GameManager : MonoBehaviour
{
    public Pool poolData;
    public GameObject enemiesContainer;
    public GameObject lootsContainer;
    public AudioClip[] clips;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -50, 0); // Cartoony Gravity
    }

    private void Start()
    {
        var playerPrefab = Globals.Tools.ObjectPooling.Grab(PoolType.Player);

        #region Camera

        new CameraFollow(playerPrefab, 2);
        #endregion

        #region Audio

        new AudioSystem(clips, this);
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
        playerBehaviours[2] = new Move(2, 4);
        playerBehaviours[3] = new Duck();
        playerBehaviours[4] = new Jump(18);
        playerBehaviours[5] = new Shoot(weapons);
        playerBehaviours[6] = new Stab();
        playerBehaviours[7] = new Pick();

        new Player(playerPrefab, playerBehaviours, this);
        #endregion

        #region Rewards

        var loot = new Loot(lootsContainer);
        #endregion

        Globals.Tools.Event.Fire(EventType.OnSFX, Globals.SoundEffects.MissionStart); // SFX
    }
}
