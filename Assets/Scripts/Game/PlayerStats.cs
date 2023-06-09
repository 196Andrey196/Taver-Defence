using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    [SerializeField] private int _curentBalance;
    public int curentBalance
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
    [SerializeField] private int _startLive;

    public int startLive
    {
        get { return _startLive; }
        set { _startLive = value; }
    }
    [SerializeField] private static int _rounds;
    public static int rounds
    {
        get { return _rounds; }
        set { _rounds = value; }
    }


    private void Start()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        _curentBalance = _startMoney;
        _curentLive = _startLive;
    }

}
