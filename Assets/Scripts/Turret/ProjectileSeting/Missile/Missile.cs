using UnityEngine;

public class Missile : SimplProjectile
{
    [SerializeField] private float _explosionRadius = 0f;

    private DamageEfect _enemyDamageEfect;
    private MissileDamage _missileDamage;
    [SerializeField] private float _timeLive = 1f;



    private void Start()
    {
        _enemyDamageEfect = GetComponent<DamageEfect>();
        _missileDamage = GetComponent<MissileDamage>();

    }
    protected override void Launch()
    {
        _timeLive -= Time.deltaTime;
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
        if (_timeLive <= 0)
        {
            Detonate();
        }
    }

    protected override void HitTarget()
    {
        Detonate();
    }
    private void Detonate()
    {
        _enemyDamageEfect.EnemyDamageEfect(_damageEfect);
        _missileDamage.Explode(_explosionRadius, _projectileTarget, _damage);
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }


}
