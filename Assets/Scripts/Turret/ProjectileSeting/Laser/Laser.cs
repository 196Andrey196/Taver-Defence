using UnityEngine;

public class Laser : ProjectileMainHaracteristics
{

    private Turret _turret;
    private TakeDamage _takeDamage;
    private Enemy _enemy;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private ParticleSystem _impactEfect;
    [SerializeField] private Light _lightImpact;
    [SerializeField] private float _slowPercent;
    private LineRenderer _lineRenderer;
    private void Start()
    {
        _turret = GetComponent<Turret>();
        _lineRenderer = GetComponent<LineRenderer>();

    }
    private void Update()
    {
        if (_turret.target == null)
        {
            _lineRenderer.enabled = false;
            _impactEfect.Stop();
            _lightImpact.enabled = false;
        }
        else
        {
            _takeDamage = _turret.target.GetComponent<TakeDamage>();
            _enemy = _turret.target.GetComponent<Enemy>();
            LaserLine();
        }
    }
    private void LaserLine()
    {
        _takeDamage.Damage(_damage * Time.deltaTime);
        SlowDown();
        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
            _impactEfect.Play();
            _lightImpact.enabled = true;

        }

        _lineRenderer.SetPosition(0, _firePoint.position);
        _lineRenderer.SetPosition(1, _turret.target.transform.position);
        Vector3 direction = _firePoint.position - _turret.target.transform.position;
        _impactEfect.transform.position = _turret.target.transform.position + direction.normalized;
        _impactEfect.transform.rotation = Quaternion.LookRotation(direction);

    }

    private void SlowDown()
    {
        _enemy.curentSpeed = _enemy.startSpeed * (1f - _slowPercent);
    }
}


