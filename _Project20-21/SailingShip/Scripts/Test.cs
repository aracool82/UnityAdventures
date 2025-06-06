using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float _angle = 90;

    private Quaternion _rightLimit;
    private Quaternion _leftLimit;

    private void Awake()
    {
        _rightLimit = Quaternion.Euler(0, _angle, 0);
        _leftLimit = Quaternion.Euler(0, -_angle, 0);
    }

    private void Update()
    {
       
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = _leftLimit;
            Debug.Log(transform.rotation.eulerAngles);
            // if (Mathf.Round(Vector3.Angle(Vector3.forward, transform.forward)) <= _angle)
            //     Rotate(-1);
            // else
            //     transform.rotation = _leftLimit;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = _rightLimit;
            Debug.Log(transform.rotation.eulerAngles);
            // if (Mathf.Round(Vector3.Angle(Vector3.forward, transform.forward)) <= _angle)
            //     Rotate(1);
            // else
            //     transform.rotation = _rightLimit;
        }
    }

    private void Rotate(float angle)
    {
        transform.Rotate(Vector3.up, angle);
    }
}