using _Project22_23.Scripts.NewNavMeshScripts;
using UnityEngine;

public class Tower : MonoBehaviour,IDirectionalRotatable
{
    [SerializeField] private float _rotationSpeed = 500f;

    private DirectionRotator _rotator;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    private void Start()
        =>_rotator = new DirectionRotator(transform, _rotationSpeed);

    private void Update()
        =>_rotator.Update(Time.deltaTime);

    public void SetRotationDirection(Vector3 direction)
        =>_rotator.SetDirection(direction);
}