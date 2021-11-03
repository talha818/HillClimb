using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    
    public float speed = 1000f;
    public float rotationspeed = 15f;

    public Rigidbody2D CarRigidbody;

    public WheelJoint2D fronttyre;
    public WheelJoint2D backtyre;


    private float movement=0f;
    private float rotaion=0f;

    private bool Ispressed;

    public float Fuel=1f;
    public float FuelConsumption=0.1f;
    public UnityEngine.UI.Image image;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = Fuel;

        if (Ispressed )
        {
            movement = -1*speed;
        }
        else
        {
            movement = 0;
        }
        //movement = -Input.GetAxisRaw ("Vertical")*speed ;
        rotaion = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        if (Fuel > 0)
        {
            if (movement == 0)
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
        }


        Fuel -= FuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;

        }



    public void Pressed()
    {
        Ispressed = true;
    }

    public void NotPressed()
    {
        Ispressed = false;
    }

    public void BreakBtnClicked()
    {
        CarRigidbody.Sleep();
    }
   





        

   
}

//fronttyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
//backtyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
//CarRigidbody.AddTorque(-movement * Torque * Time.fixedDeltaTime);


