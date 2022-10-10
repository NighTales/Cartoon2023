using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points;
    [SerializeField]
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.positionCount = points.Count;
    }

    void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Transform item = points[i];
            if (item != null)
            {
                lineRenderer.SetPosition(i, item.position);
            }
        }
    }
}
