using UnityEngine;

public class CheсkTarget : MonoBehaviour
{

    private TurretBluprint _turretBluprint;
    private string _enemyTag = "Enemy";
   
    private float _startTime = 0f;
    private float _nextUpdate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", _startTime, _nextUpdate);
    }

    private void UpdateTarget()
    {
        

        Turret turret = GetComponent<Turret>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        Vector3 originalPos = transform.position;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= turret.targetRange) turret.target = nearestEnemy;
        else turret.target = null;
    }
    private void OnDrawGizmos()
    {
        float targetRange = GetComponent<Turret>().targetRange;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, targetRange);
    }
    
}
