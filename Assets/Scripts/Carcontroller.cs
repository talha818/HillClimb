using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    public Rigidbody2D CarRigidbody;
    public Rigidbody2D fronttyre;
    public Rigidbody2D backtyre;
    private  float movement;
    public float speed = 20;
    public float Torque = 20;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input .GetKey  (KeyCode.RightArrow))
        {
            movement = Input.GetAxis("Horizontal");
        }
        //movement = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        fronttyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
        backtyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
        CarRigidbody.AddTorque(-movement * Torque * Time.fixedDeltaTime);


    }
}
