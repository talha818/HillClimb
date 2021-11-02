using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform Playerpos;
    public Vector3 velocity;
    public float Smoothness;

    Vector3 StartPoint;

    private void Start()
    {
        //offset = transform.position - target.position;
        StartPoint = transform.position;
    }

    private void Update()
    {
        Vector3 target = new Vector3(Playerpos.position.x, Playerpos.position.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, Smoothness);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision . CompareTag("StartPoint"))
        {
            transform.position = StartPoint;
        }
    }
}
