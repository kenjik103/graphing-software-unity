using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class Graph: MonoBehaviour
{
    [SerializeField] 
    Transform pointPrefab;

    [SerializeField, Range(10,100)] 
    int resolution = 10;

    Transform[] points;
    
    void Awake() {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i] = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    void Update() {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI* position.x + time);
            point.localPosition = position;
        }
    }
}