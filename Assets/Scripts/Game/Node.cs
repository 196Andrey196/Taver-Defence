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
    private void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (_buildManager.canBuild || EventSystem.current.IsPointerOverGameObject()) return;
        if (_buildManager.hasMoney) _renderer.material.color = _toBuildColor;
        else _renderer.material.color = _cantBuildColor;
    }
    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
    private void OnMouseDown()
    {
        if (_turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }


        _buildManager.BuildTurretOn(this);
    }

}
