using UnityEngine;
using TMPro;

[System.Serializable]
public class TurretBluprint
{
    [SerializeField] private GameObject _prefab;

    public GameObject prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }
    
        [SerializeField] private TextMeshProUGUI _turetCost;

    public TextMeshProUGUI turetTextCost
    {
        get { return _turetCost; }
        set { _turetCost = value; }
    }
    



}
