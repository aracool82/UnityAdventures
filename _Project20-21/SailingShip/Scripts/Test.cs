using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private Vector3 _rotationEuler;
    [SerializeField] private float _angle = 90;

    private Quaternion _rightLimit = Quaternion.Euler(0, 90, 0);
    private Quaternion _leftLimit = Quaternion.Euler(0, -90, 0);

    private void Start()
    {
    }

    private void Update()
    {
        _rotation = transform.rotation;
        _rotationEuler = transform.rotation.eulerAngles;


        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newRotationEuler = transform.rotation.eulerAngles + Vector3.up;
            transform.rotation = Quaternion.Euler(newRotationEuler);

            Debug.Log($"transY:{transform.rotation.eulerAngles.y}");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newRotationEuler = transform.rotation.eulerAngles - Vector3.up;
            transform.rotation = Quaternion.Euler(newRotationEuler);
            Debug.Log($"transY:{transform.rotation.eulerAngles.y}");
        }
    }
}