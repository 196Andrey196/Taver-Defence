using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public static int enemiesAlive;
    private bool _gameVone;
    [SerializeField] private int _curentEnemyCount;
    public TextMeshProUGUI _waveCountDownText;
    [SerializeField] private WaveSetting[] _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private float _countDown;
    [SerializeField] private int _waveIndex;

    private void Start()
    {
        _gameVone = false;
    }
    private void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        SpawnTimer();
        _curentEnemyCount = enemiesAlive;
        if (_waveIndex == _waves.Length)
        {
            this.enabled = false;
            GameManager.instance.WinLevel();
        }
  

    }

    private void SpawnTimer()
    {

        if (_countDown <= 0f)
        {
            Debug.Log(1);
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
            return;
        }
        _countDown -= Time.deltaTime;

        _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);
        _waveCountDownText.text = string.Format("{0:00.00}", _countDown);
    }

    private IEnumerator SpawnWave()
    {
        WaveSetting wave = _waves[_waveIndex];
        PlayerStats.instance.rounds++;
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        _waveIndex++;


    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);

    }
}
