using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUi : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    private Node _node;
    private Turret _turretParameters;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _upgradeTuretText;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TextMeshProUGUI _sellTuretText;


    public void SetTarget(Node node)
    {
        ShowParam(true);
        _turretParameters = node.turret.GetComponent<Turret>();
        _turretParameters.sellCost = _turretParameters.cost / 2;
        _sellTuretText.text = "<b>Sell</b>\n $ " + _turretParameters.sellCost.ToString();
        _node = node;
        transform.position = node.turret.transform.position;
        if (!_turretParameters.isUpgraded)
        {
            _upgradeTuretText.text = "<b>Upgrade</b>\n $ " + _turretParameters.upgradeCost.ToString();
            _upgradeButton.interactable = true;
        }
        else
        {
            _upgradeTuretText.text = "<b>Upgrade Done</b>";
            _upgradeButton.interactable = false;
        }

    }
    public void ShowParam(bool val)
    {
        _ui.SetActive(val);
    }

    public void Upgrade()
    {
        if (!_turretParameters.isUpgraded && _node.turret != null)
        {
            BuildManager.instance.UpgradeTurret(_node);
        }
        else
        {
            Debug.Log("You Can't Upgrade!!!");
        }
        ShowParam(false);

    }
    public void Sell()
    {

        PlayerStats.instance.curentBalance += _turretParameters.cost / 2;
        ShowParam(false);
        Destroy(_node.turret);
    
    }
}
