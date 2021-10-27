using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    
    public float speed = 1500f;
    public float rotationspeed = 15f;

    public Rigidbody2D CarRigidbody;

    public WheelJoint2D fronttyre;
    public WheelJoint2D backtyre;


    private float movement=0f;
    private float rotaion=0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        movement = -Input.GetAxisRaw ("Vertical")*speed ;
        rotaion = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        if (movement ==0)
        {
            fronttyre.useMotor = false;
            backtyre.useMotor = false;

        }
        else
        {
            fronttyre.useMotor = true;
            backtyre.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000f };
            fronttyre.motor = motor;
            backtyre.motor = motor;

            
        }

        CarRigidbody.AddTorque(rotaion * rotationspeed * Time.fixedDeltaTime);









        //fronttyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
        //backtyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
        //CarRigidbody.AddTorque(-movement * Torque * Time.fixedDeltaTime);


    }
}
