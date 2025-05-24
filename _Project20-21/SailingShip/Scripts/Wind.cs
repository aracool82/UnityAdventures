using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Ship _ship;

    [SerializeField] private float _strength;

    [SerializeField] private float _ChangeDirectionTime;
    private float _time;
    
    public Vector3 Direction => transform.forward;

    private void Update()
    {
        transform.position = new Vector3(_ship.transform.position.x, transform.position.y, _ship.transform.position.z);
        _time += Time.deltaTime;

        if (_time >= _ChangeDirectionTime)
        {
            _time = 0;
            float angleY = Random.Range(0f, 180);
            transform.rotation = Quaternion.Euler(new Vector3(0,angleY, 0));
        }

        
    }

    private Vector3 GetRandomDirection()
    {
        List<Vector3> directions = new List<Vector3>(){ Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        return directions[Random.Range(0, directions.Count)];
    }
}