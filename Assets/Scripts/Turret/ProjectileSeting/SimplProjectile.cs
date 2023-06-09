using UnityEngine;

public class SimplProjectile : ProjectileMainHaracteristics
{
    [SerializeField] protected GameObject _projectileTarget;

    public GameObject projectileTarget
    {
        get { return _projectileTarget; }
        set { _projectileTarget = value; }
    }
    [SerializeField] protected int _speed;
    public int speed
    {
        get { return _speed; }
    }
    [SerializeField] protected GameObject _damageEfect;
    private void Update()
    {
        Launch();
    }
    protected virtual void Launch() { }

    protected virtual void HitTarget() { }
}
