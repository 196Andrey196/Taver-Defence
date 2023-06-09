using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    public float startSpeed
    {
        get { return _startSpeed; }
    }
    [SerializeField] private float _curentSpeed;
    public float curentSpeed
    {
        get { return _curentSpeed; }
        set { _curentSpeed = value; }
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
    private void Start()
    {
        _curentSpeed = _startSpeed;
    }

}
