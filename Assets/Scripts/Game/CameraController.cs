using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _panoramSpeed;
    [SerializeField] private float _scrolSpeed;
    [SerializeField] private float _minY = 10f;
    [SerializeField] private float _maxY = 75f;
    [SerializeField] private float _axiX;
    [SerializeField] private float _axiZ;



    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return)) transform.position = new Vector3(0f, _maxY, 0f);
        KeyBoardMove();
        ScrolMouse();

    }

    private void ScrolMouse()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= mouseScroll * 1000 * _scrolSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, _minY, _maxY);
        transform.position = position;
    }
    private void KeyBoardMove()
    {

        if (Input.GetKey("w") && transform.position.z <= _axiZ)
        {
            transform.Translate(Vector3.forward * _panoramSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") && transform.position.z >= -_axiZ)
        {
            transform.Translate(Vector3.back * _panoramSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") && transform.position.x <= _axiX)
        {
            transform.Translate(Vector3.right * _panoramSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") && transform.position.x >= -_axiX)
        {
            transform.Translate(Vector3.left * _panoramSpeed * Time.deltaTime, Space.World);
        }

    }



}
