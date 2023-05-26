using UnityEngine;

public class RotateMissileToTarget : MonoBehaviour
{
    private Missile _missile;
    [SerializeField] private float _rotationSpeed;


    private void Start()
    {
        _missile = GetComponent<Missile>();
    }

    private void Update()
    {
        Vector3 direction = (_missile.projectileTarget.transform.position - transform.position).normalized;
        Quaternion rotGoal = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, _rotationSpeed * Time.deltaTime);
        
    }
}
