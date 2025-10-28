using System.Collections.Generic;
using UnityEngine;

namespace _Project29_30.Scripts
{
    public class Storage<T> : MonoBehaviour where T : MonoBehaviour

    {
    private List<T> _apples = new();

    public Vector3 GetRandomPosition()
        => GetRandom().transform.position;

    public T GetRandom()
        => _apples[Random.Range(0, _apples.Count)];

    public void Add(T apple)
    {
        if (_apples.Contains(apple))
        {
            Debug.LogError($" {nameof(apple)} Is already exist");
            return;
        }

        _apples.Add(apple);
    }

    public void Remove(T apple)
    {
        if (_apples.Contains(apple) == false)
        {
            Debug.LogError($" {nameof(apple)} not exist");
            return;
        }

        _apples.Remove(apple);
    }
    }
}