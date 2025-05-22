using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class PointToPoint : MonoBehaviour
    {
        Queue<Vector3> points = new Queue<Vector3>();
        private float _timeToNext = 2f;
        private float _time = 0f;
        private Vector3 _point;

        private void Awake()
        {
            points.Enqueue(new Vector3(6f, 0.5f, 0));
            points.Enqueue(new Vector3(-6f, 0.5f, 0));
            points.Enqueue(new Vector3(0, 0.5f, 6f));
            points.Enqueue(new Vector3(0, 0.5f, -6f));
            transform.position = GetPoint();
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _timeToNext)
            {
                _time = 0;
                transform.position = GetPoint();
            }
        }

        private Vector3 GetPoint()
        {
            Vector3 point = points.Dequeue();
            points.Enqueue(point);
            return point;
        }
    }
}