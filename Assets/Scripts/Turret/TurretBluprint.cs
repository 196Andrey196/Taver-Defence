using UnityEngine;
using TMPro;


public class TurretBluprint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public GameObject prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }

    [SerializeField] private GameObject _upgradePrefab;

    public GameObject upgradePrefab
    {
        get { return _upgradePrefab; }
        set { _upgradePrefab = value; }
    }
}
