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
    
    void Awake() {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        
        for (int i = 0; i < resolution; i++) {
            Transform point = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    } 
}