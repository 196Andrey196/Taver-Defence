using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private static int _curentBalance;
    public static int curentBalance
    {
        get { return _curentBalance; }
        set { _curentBalance = value; }
    }
    [SerializeField] private int _startMoney = 400;

    public int startMoney
    {
        get { return _startMoney; }
        set { _startMoney = value; }
    }

    [SerializeField] private static int _curentLive;
    public static int curentLive
    {
        get { return _curentLive; }
        set { _curentLive = value; }
    }
    [SerializeField] private int _startLive = 10;

    public int startLive
    {
        get { return _startLive; }
        set { _startLive = value; }
    }


    private void Start()
    {
        _curentBalance = _startMoney;
        _curentLive = _startLive;
    }
}
