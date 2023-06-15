using UnityEngine;

[System.Serializable]
public class WaveSetting
{
    [SerializeField] private GameObject _enemy;
    public GameObject enemy
    {
        get { return _enemy; }
    }
    [SerializeField] private int _count;
    public int count
    {
        get { return _count; }
        set { _count = value; }
    }
    [SerializeField] private float _rate;
    public float rate
    {
        get { return _rate; }
        set { _rate = value; }
    }
}
