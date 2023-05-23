using UnityEngine;
using TMPro;


public class ShoppingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    private void Start()
    {
        _money.text = "$" + PlayerStats.curentBalance.ToString();
    }
    private void Update()
    {
        UpdateCurentBalance();
    }
    public void BuyTurret(int turretCost)
    {

        if (PlayerStats.curentBalance < turretCost)
        {
            Debug.Log("Not enough money  to build turet");
            return;
        }
        PlayerStats.curentBalance -= turretCost;
        UpdateCurentBalance();

    }
    private void UpdateCurentBalance()
    {
        _money.text = "$" + PlayerStats.curentBalance.ToString();
    }

}
