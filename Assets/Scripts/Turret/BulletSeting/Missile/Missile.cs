using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] private float _explosionRadius = 0f;

    private DamageEfect _enemyDamageEfect;
    private MissileDamage _missileDamage;



    private void Start()
    {
        _enemyDamageEfect = GetComponent<DamageEfect>();
        _missileDamage = GetComponent<MissileDamage>();

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
        if (_explosionRadius > 0f)
        {
            _missileDamage.Explode(_explosionRadius,_projectileTarget,_damage);
        }

        Destroy(gameObject);
    }
       private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_explosionRadius);
    }


}
