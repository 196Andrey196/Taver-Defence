using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _toBuildColor;
    [SerializeField] private Color _cantBuildColor;
    [SerializeField] private GameObject _turret;
    public GameObject turret
    {
        get { return _turret; }
        set { _turret = value; }
    }
    [SerializeField] private Vector3 _positionOffset;
    public Vector3 positionOffset
    {
        get { return transform.position + _positionOffset; }
    }
    private Color _startColor;
    private Renderer _renderer;
    private BuildManager _buildManager;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _buildManager = BuildManager.instance;
        _startColor = _renderer.material.color;
    }

    private void OnMouseEnter()
    {
        if (!_buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject()) return;
        if (_buildManager.HasMoney) _renderer.material.color = _toBuildColor;
        else _renderer.material.color = _cantBuildColor;


    }
    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
    private void OnMouseDown()
    {
        if (!_buildManager.CanBuild || EventSystem.current.IsPointerOverGameObject()) return;
        if (_turret != null)
        {
            //TODO MASAGE: Dispaly on screen
            Debug.Log("Can't build there!");
            return;
        }
        _buildManager.BuildTurretOn(this);
    }
}
