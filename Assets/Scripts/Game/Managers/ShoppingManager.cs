using UnityEngine;
using TMPro;


public class ShoppingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    public static ShoppingManager instance;
    private void Start()
    {
        CurentBalance();
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Update()
    {
        CurentBalance();

    }
    public void PurchaseTurret(int turretCost)
    {

        PlayerStats.instance.curentBalance -= turretCost;


    }
    private void CurentBalance()
    {
        _money.text = "$" + PlayerStats.instance.curentBalance.ToString();
    }

}
