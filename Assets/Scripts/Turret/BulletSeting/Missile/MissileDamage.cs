using System;
using UnityEngine;

public class MissileDamage : MonoBehaviour
{


    public void Explode(float explosionRadius, GameObject target, int damage)
    {
        TakeDamage enemyTakeDamage = target.GetComponent<TakeDamage>();
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider enemyCollider in enemyColliders)
        {
            if (enemyCollider.tag == "Enemy")
            {
                enemyTakeDamage.Damage(damage);
            }
        }
    }
}



