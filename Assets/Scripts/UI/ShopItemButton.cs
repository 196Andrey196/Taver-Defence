using UnityEngine;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
    private BuildManager _buildManager;
    [SerializeField] private TurretBluprint _standartTurretInfo;
    [SerializeField] private TurretBluprint _missileLaucherInfo;
    [SerializeField] private TurretBluprint _laserBeamerInfo;


    private void Start()
    {
        _buildManager = BuildManager.instance;
        SetItemCost(_standartTurretInfo.prefab, _standartTurretInfo.turetTextCost);
        SetItemCost(_missileLaucherInfo.prefab, _missileLaucherInfo.turetTextCost);
        SetItemCost(_laserBeamerInfo.prefab, _laserBeamerInfo.turetTextCost);

    }

    public void SelectStandartTurret()
    {

        _buildManager.SelectTurretToBuild(_standartTurretInfo);
    }

    public void SelectLaserBeamer()
    {

        _buildManager.SelectTurretToBuild(_laserBeamerInfo);
    }
    public void SelectMissileLaucher()
    {

        _buildManager.SelectTurretToBuild(_missileLaucherInfo);
    }
    private void SetItemCost(GameObject prefab, TextMeshProUGUI textCost)
    {
        Turret itemDate = prefab.GetComponent<Turret>();
        int turretCost = itemDate.cost;
        textCost.text = "$" + turretCost;

    }
}
