using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private int _turretCost;
    [SerializeField] private GameObject _turretToBuild;

    [SerializeField] private GameObject _turretToUpgrade;
    private Node _selectedNode;
    [SerializeField] bool _buildMode;
    public bool buildMode
    {
        get { return _buildMode; }
        set { _buildMode = value; }
    }
    [SerializeField] private NodeUi _nodeUi;
    [SerializeField] private GameObject _buildEfect;

    // [SerializeField] private GameObject _sellEfect;
    // public GameObject sellEfect { get { return _sellEfect; } }
    public bool canBuild { get { return _buildMode == false; } }
    public bool hasMoney { get { return PlayerStats.instance.curentBalance >= _turretCost; } }


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        buildMode = false;
        _turretToBuild = null;
    }

    public void SelectTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
        _selectedNode = null;

    }
    public void SelectNode(Node node)
    {
        bool isUpgraded = node.turret.GetComponent<Turret>().isUpgraded;
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        if (!isUpgraded)
        {
            GameObject upgradeTurret = node.turret.GetComponent<TurretBluprint>().upgradePrefab;
            _turretToUpgrade = upgradeTurret;
        }
        _selectedNode = node;
        _nodeUi.SetTarget(node);

    }

    public void DeselectNode()
    {
        _selectedNode = null;
        _nodeUi.ShowParam(false);
    }


    internal void BuildTurretOn(Node node)
    {
        Turret _turretParameters = _turretToBuild.GetComponent<Turret>();
        _turretCost = _turretParameters.cost;
        if (_buildMode == true && PlayerStats.instance.curentBalance >= _turretCost)
        {

            ShoppingManager.instance.PurchaseTurret(_turretCost);
            GameObject newTurret = Instantiate(_turretToBuild, node.positionOffset, Quaternion.identity);
            node.turret = newTurret;
            BuildEfect(node);
            buildMode = false;
            _turretToBuild = null;
        }

    }
    internal void UpgradeTurret(Node node)
    {
        DeselectNode();
        Turret _turretParameters = node.turret.GetComponent<Turret>();
        int upgradeTurretCost = _turretParameters.upgradeCost;
        if (PlayerStats.instance.curentBalance >= upgradeTurretCost && _buildMode == false)
        {
            Destroy(node.turret);
            ShoppingManager.instance.PurchaseTurret(upgradeTurretCost);
            GameObject newTurret = Instantiate(_turretToUpgrade, node.positionOffset, Quaternion.identity);
            node.turret = newTurret;
            BuildEfect(node);
            _turretParameters.isUpgraded = true;
            _turretToUpgrade = null;

        }

    }


    private void BuildEfect(Node node)
    {
        GameObject efect = Instantiate(_buildEfect, node.positionOffset, Quaternion.identity);
        Destroy(efect, 5f);
    }

}
