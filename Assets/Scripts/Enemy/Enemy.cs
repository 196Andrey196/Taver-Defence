using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float speed
    {
        get { return _speed; }
    }
    [SerializeField] private float _health;
    public float health
    {
        get { return _health; }
        set { _health = value; }
    }
    [SerializeField] private int _costToDie;
    public int costToDie
    {
        get { return _costToDie; }
    }
    [SerializeField] GameObject _dieEfect;
    public GameObject dieEfect
    {
        get { return _dieEfect; }
    }


}
