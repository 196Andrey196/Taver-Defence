using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public void Damage(GameObject target, float damage)
    {
        TakeDamage enemyTakeDamage = target.GetComponent<TakeDamage>();
        enemyTakeDamage.Damage(damage);
    }
}
