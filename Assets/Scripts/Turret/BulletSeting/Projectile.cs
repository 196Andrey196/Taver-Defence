using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;

    public int damage
    {
        get { return _damage; }
    }
    [SerializeField] protected GameObject _projectileTarget;

    public GameObject projectileTarget
    {
        get { return _projectileTarget; }
        set { _projectileTarget = value; }
    }
    [SerializeField] protected GameObject _damageEfect;
    private void Update()
    {
        Launch();
    }
    protected virtual void Launch() { }

    protected virtual void HitTarget() { }

}
