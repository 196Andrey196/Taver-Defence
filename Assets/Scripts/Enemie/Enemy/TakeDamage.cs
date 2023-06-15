using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _curentHealth;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _curentHealth = _enemy.startHealth;
    }

    private void Update()
    {
        if (_curentHealth <= 0)
        {
            Die();
        }
    }
    public void Damage(float amount)
    {
        _curentHealth -= amount;
        _healthBar.fillAmount = _curentHealth / _enemy.startHealth;
    }

    private void Die()
    {

        PlayerStats.instance.curentBalance += _enemy.costToDie;
        WaveSpawner.enemiesAlive--;
        GameObject dieEfect = Instantiate(_enemy.dieEfect, transform.position, transform.rotation);
        Destroy(dieEfect, 1f);
        Destroy(gameObject);
    }
}
