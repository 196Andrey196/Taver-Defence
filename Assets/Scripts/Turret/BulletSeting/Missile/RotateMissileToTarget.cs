using UnityEngine;

public class RotateMissileToTarget : MonoBehaviour
{
    private Missile _missile;
    [SerializeField] private float _rotationSpeed; // Скорость поворота ракеты
    private Quaternion _rotGoal; 
    Vector3 direction;

    private void Start()
    {
        _missile = GetComponent<Missile>();
    }

    private void Update()
    {
        direction = (_missile.projectileTarget.transform.position - transform.position).normalized;
        _rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation,_rotGoal,_rotationSpeed * Time.deltaTime);
    }
}
