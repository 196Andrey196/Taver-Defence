using UnityEngine;

public class FireEfect : MonoBehaviour
{
     [SerializeField] private GameObject _shootEfect;
   
    public void Fireshot()
    {
        GameObject efectInstance = Instantiate(_shootEfect, transform.position, transform.rotation);
        Destroy(efectInstance, 1f);
    }
}
