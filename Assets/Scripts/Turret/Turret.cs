using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Seting Turret")]
    [SerializeField] private int _cost;
    public int cost
    {
        get { return _cost; }
        set { _cost = value; }
    }
    [SerializeField] private float _speedRotation = 11f;
    public float speedRotation
    {
        get { return _speedRotation; }
    }
    [SerializeField] private float _targetRange;
    public float targetRange
    {
        get { return _targetRange; }
    }
    [Header("Seting Guns")]
    [SerializeField] private float _fireRate;
    public float fireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }
    [SerializeField] private float _fireCountDown;
    public float fireCountDown
    {
        get { return _fireCountDown; }
        set { _fireCountDown = value; }
    }

    [Header("Target to Attack")]
    [SerializeField] private GameObject _target;
    public GameObject target
    {
        get { return _target; }
        set { _target = value; }
    }


}
