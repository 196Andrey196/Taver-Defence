using UnityEngine;

public class RotateToTarget : MonoBehaviour
{

    [SerializeField] private Transform _partToRotation;

    // Update is called once per frame


    void Update()
    {

        RotateToDirection();
    }
    private void RotateToDirection()
    {

        GameObject target = GetComponent<Turret>().target;
        float speedRotation = GetComponent<Turret>().speedRotation;
        Vector3 lookToDirection;

        if (target != null)
        {
            lookToDirection = target.transform.position - transform.position;
        }
        else lookToDirection = Vector3.zero;

        Quaternion lookRotation = Quaternion.LookRotation(lookToDirection);
        Vector3 rotation = Quaternion.Lerp(_partToRotation.rotation, lookRotation, Time.deltaTime * speedRotation).eulerAngles;
        _partToRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }
}
