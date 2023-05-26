using UnityEngine;

public class Laser : MonoBehaviour
{

    private Turret _turret;
    private bool _useLaser = false;
    [SerializeField] private Transform _firePoint;
    private LineRenderer _lineRenderer;
    private void Start()
    {
        _turret = GetComponent<Turret>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (_turret.target == null)
        {
            _lineRenderer.enabled = false;
        }
        else
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, _turret.target.transform.position);
        }

    }


}


