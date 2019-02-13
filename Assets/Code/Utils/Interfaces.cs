public interface IBehaviour : ICloneable<IBehaviour>
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

public interface ISpawnable
{
    void Init(object obj);
}

public interface ICloneable<T>
{
    T Clone();
}

