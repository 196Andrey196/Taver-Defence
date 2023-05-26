using System;
using UnityEngine;

public class MissileDamage : MonoBehaviour
{


    public void Explode(float explosionRadius, GameObject target, int damage)
    {
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider enemyCollider in enemyColliders)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                TakeDamage enemyTakeDamage = enemyCollider.GetComponent<TakeDamage>();
                if (enemyTakeDamage != null)
                {
                    enemyTakeDamage.Damage(damage);
                }
            }
        }
    }

}



