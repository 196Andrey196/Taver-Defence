using UnityEngine;

public class DamageEfect : MonoBehaviour
{

    public void EnemyDamageEfect(GameObject damageEfect)
    {
        GameObject efectInstance = Instantiate(damageEfect, transform.position, transform.rotation);
        Destroy(efectInstance, 2f);
    }
}