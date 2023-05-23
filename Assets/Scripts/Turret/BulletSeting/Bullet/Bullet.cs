using UnityEngine;

public class Bullet : Projectile
{
       private DamageEfect _enemyDamageEfect;
       private BulletDamage _bulletDamage;


    private void Start()
    {
        _enemyDamageEfect = GetComponent<DamageEfect>();
        _bulletDamage = GetComponent<BulletDamage>();

    }
    protected override void Launch()
    {
        if (_projectileTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = _projectileTarget.transform.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    protected override void HitTarget()
    {
        _enemyDamageEfect.EnemyDamageEfect(_damageEfect);
        _bulletDamage.Damage(_projectileTarget,_damage);
        Destroy(gameObject);
    }
}
