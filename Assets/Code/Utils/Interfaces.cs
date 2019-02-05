public interface IBehaviour
{
    void Init(object obj);
}

public interface IWeapon
{
    void Init(object obj);
    void Shoot();
}

public interface IReward
{
    void GetReward(object obj);
}

