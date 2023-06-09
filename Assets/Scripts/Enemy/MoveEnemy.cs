using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Enemy _enemy;
    private int _wavePointIndex = 0;
    private Transform _target;

    private void Start()
    {
        _target = WayPoints.points[0];
        _enemy = GetComponent<Enemy>();

    }

    private void Update()
    {
        MoveToPoint();
        _enemy.curentSpeed = _enemy.startSpeed;
    }

    private void MoveToPoint()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.curentSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        EndPathg();

        _wavePointIndex++;
        if (_wavePointIndex < WayPoints.points.Length)
        {
            _target = WayPoints.points[_wavePointIndex];
        }
    }

    private void EndPathg()
    {

        if (_wavePointIndex >= WayPoints.points.Length - 1 && PlayerStats.curentLive > 0)
        {
            PlayerStats.curentLive--;
            Destroy(gameObject);
            return;
        }
    }
}
