using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points;
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private bool debug = false;

    private void Start()
    {
        lineRenderer.positionCount = points.Count;
    }

    void Update()
    {
        CheckLine();
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            CheckLine();
        }
    }

    private void CheckLine()
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
