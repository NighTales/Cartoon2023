using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    void Update()
    {
        transform.Rotate(myTransform.up, speed * Time.deltaTime);
    }
}
