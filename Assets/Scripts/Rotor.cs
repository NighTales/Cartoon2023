using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private Vector3 axis = Vector3.up;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
