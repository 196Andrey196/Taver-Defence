using UnityEngine;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
    public static ShopItemButton instance;
    private BuildManager _buildManager;
    [SerializeField] private TurretBluprint _standartTurret;
    [SerializeField] private TextMeshProUGUI _standartTurretCost;

    [SerializeField] private TurretBluprint _missileLaucher;
    [SerializeField] private TextMeshProUGUI _missileLaucherCost;

    [SerializeField] private TurretBluprint _laserBeamer;
    [SerializeField] private TextMeshProUGUI _laserBeamerCost;


    private void Start()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        _buildManager = BuildManager.instance;
        SetItemCost(_standartTurret.prefab, _standartTurretCost);
        SetItemCost(_missileLaucher.prefab, _missileLaucherCost);
        SetItemCost(_laserBeamer.prefab, _laserBeamerCost);
    }

    public void SelectStandartTurret()
    {
        _buildManager.DeselectNode();
        _buildManager.buildMode = true;
        _buildManager.SelectTurretToBuild(_standartTurret.prefab);

    }

    public void SelectLaserBeamer()
    {
        _buildManager.DeselectNode();
        _buildManager.buildMode = true;
        _buildManager.SelectTurretToBuild(_laserBeamer.prefab);

    }
    public void SelectMissileLaucher()
    {
        _buildManager.DeselectNode();
        _buildManager.buildMode = true;
        _buildManager.SelectTurretToBuild(_missileLaucher.prefab);

    }
    private void SetItemCost(GameObject prefab, TextMeshProUGUI textCost)
    {
        Turret itemDate = prefab.GetComponent<Turret>();
        int turretCost = itemDate.cost;
        textCost.text = "$" + turretCost;
    }
}
