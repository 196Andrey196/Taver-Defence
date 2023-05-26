using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public void Damage(GameObject target, int damage)
    {
        TakeDamage enemyTakeDamage = target.GetComponent<TakeDamage>();
        enemyTakeDamage.Damage(damage);
    }
}
