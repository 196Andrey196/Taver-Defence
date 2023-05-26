using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private ShoppingManager _shoppingManager;
    private int _turretCost;
    private Turret _turretParameters;
    private TurretBluprint _turretToBuild;
    [SerializeField] private GameObject _buildEfect;
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.curentBalance >= _turretCost; } }


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        _shoppingManager = GetComponent<ShoppingManager>();
    }

    public void SelectTurretToBuild(TurretBluprint turret)
    {
        _turretToBuild = turret;
    }

    internal void BuildTurretOn(Node node)
    {
        _turretParameters = _turretToBuild.prefab.GetComponent<Turret>();
        GameObject turretPrefab = _turretToBuild.prefab;
        _turretCost = _turretParameters.cost;
        if (PlayerStats.curentBalance >= _turretCost)
        {
            GameObject newTurret = Instantiate(turretPrefab, node.positionOffset, Quaternion.identity);
            node.turret = newTurret;
            _shoppingManager.BuyTurret(_turretCost);
            BuildEfect(node);
        }


    }
    private void BuildEfect(Node node)
    {
        GameObject efect = Instantiate(_buildEfect, node.positionOffset, Quaternion.identity);
        Destroy(efect, 5f);
    }

}
