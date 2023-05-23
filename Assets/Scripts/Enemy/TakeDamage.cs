using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (_enemy.health <= 0)
        {
            Die();
        }
    }
    public void Damage(int amount)
    {
        _enemy.health -= amount;
    }

    private void Die()
    {
        PlayerStats.curentBalance += _enemy.costToDie;
        Debug.Log(_enemy.costToDie + "+ on balance");
        GameObject dieEfect = Instantiate(_enemy.dieEfect, transform.position, transform.rotation);
        Destroy(dieEfect, 1f);
        Destroy(gameObject);
    }
}
