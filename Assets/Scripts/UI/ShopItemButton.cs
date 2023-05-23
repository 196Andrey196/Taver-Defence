using UnityEngine;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
    private BuildManager _buildManager;
    [SerializeField] private TurretBluprint _standartTurretPrefab;
    [SerializeField] private TurretBluprint _missileLaucherPrefab;


    private void Start()
    {
        _buildManager = BuildManager.instance;
        SetItemCost(_standartTurretPrefab.prefab, _standartTurretPrefab.turetTextCost);
        SetItemCost(_missileLaucherPrefab.prefab, _missileLaucherPrefab.turetTextCost);

    }

    public void SelectStandartTurret()
    {

        _buildManager.SelectTurretToBuild(_standartTurretPrefab);
    }

    public void SelectMissileLaucher()
    {

        _buildManager.SelectTurretToBuild(_missileLaucherPrefab);
    }
    private void SetItemCost(GameObject prefab, TextMeshProUGUI textCost)
    {
        Turret itemDate = prefab.GetComponent<Turret>();
        int turretCost = itemDate.cost;
        textCost.text = "$" + turretCost;

    }
}
