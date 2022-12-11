using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTarget : MonoBehaviour
{
    public List<Soul> souls;

    [SerializeField]
    private SoulCubeSpawner cubeSpawner;
    [SerializeField]
    Transform soulCollectorPoint;

    Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Update()
    {
        if(Vector3.Distance(myTransform.position, soulCollectorPoint.position) < 0.3f)
        {
            ClearAllSouls();
        }
    }

    public void ClearAllSouls()
    {
        if (souls.Count > 0)
        {
            cubeSpawner.SpawnCubes(souls);
            for (int i = 0; i < souls.Count; i++)
            {
                Destroy(souls[i].gameObject);
            }
            souls.Clear();
        }
    }
}
