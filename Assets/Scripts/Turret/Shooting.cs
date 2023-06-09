using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _Projectile;
    [SerializeField] private Transform _firePoint;

    // Update is called once per frame
    void Update()
    {
        Turret turret = GetComponent<Turret>();


        if (turret.target == null) return;

        else
        {
            if (turret.fireCountDown <= 0f)
            {
                Shoot();
                turret.fireCountDown = 1f / turret.fireRate;
            }
            turret.fireCountDown -= Time.deltaTime;
        }

    }

    private void Shoot()
    {
        GameObject target = GetComponent<Turret>().target;
        FireEfect fireEfect = _firePoint.GetComponent<FireEfect>();
        fireEfect.Fireshot();
        GameObject buletGo = (GameObject)Instantiate(_Projectile, _firePoint.position, _firePoint.rotation);
        SimplProjectile projectile = buletGo.GetComponent<SimplProjectile>();
        if (projectile != null) projectile.projectileTarget = target;
    }

}
