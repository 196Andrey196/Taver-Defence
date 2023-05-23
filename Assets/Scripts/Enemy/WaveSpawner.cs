using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{


    public TextMeshProUGUI _waveCountDownText;
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _countDown = 2f;
    [SerializeField] private int _waveIndex = 0;

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }
        _countDown -= Time.deltaTime;

        _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);
        _waveCountDownText.text = string.Format("{0:00.00}", _countDown);
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }
}
