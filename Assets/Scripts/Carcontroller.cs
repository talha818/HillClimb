using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public float FuelConsumption=0.5f;
    public Image FuelImage;


    public GameObject PausePanel;
   
    public  GameObject PauseBtn;
    public GameObject WinPanel;
    public GameObject GameOverPanel;

    public AudioSource GameSound;
    public AudioClip FuelClip;
    
    public AudioClip Gameoverclip;

    public AudioClip Winclip;
    //public AudioClip Gameoverclip;

    


    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        FuelImage.fillAmount = Fuel;

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

                Fuel -= FuelConsumption * Time.fixedDeltaTime;

              
            }
            
            
        }
        if (Fuel <0)
        {
            BreakBtnClicked();
           // Time.timeScale = 0f;
            //OpenParachute();
        }

        //Fuel -= FuelConsumption * Time.fixedDeltaTime;
       

    }



    public void Pressed()
    {
        Ispressed = true ;
    }

    public void NotPressed()
    {
        Ispressed = false;
    }

    public void BreakBtnClicked()
    {
        CarRigidbody.Sleep();
    }






    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Fuel")
        {

            Fuel = 1f;
            GameSound.PlayOneShot(FuelClip);

            Destroy(c.gameObject);
        }

        
    }


    public void PauseBtnClicked()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }


    public void MainMenuBtnClicked()
    {
        SceneManager.LoadScene(1);
    }


    public void ResumeBtnClicked()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "WinLine")
        {
            GameSound.PlayOneShot(Winclip );
            Debug.Log("WinGame");
            WinPanelClicked();
        }

        if (collision.gameObject.tag == "Ground")
        {
            GameSound.PlayOneShot(Gameoverclip);
            Debug.Log("Gameover");
            GameOverPanelClicked();
        }

    }


    


   
    public void WinPanelClicked()
    {
        coindel.ShowHighScore();
        coindel.SaveHighscore();
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReplayBtnClicked()
    {
        SceneManager.LoadScene(2);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReplayBtnClickedLevel2()
    {
        SceneManager.LoadScene(3);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOverPanelClicked()
    {
        if (GameOverPanel == true)
        {
          PauseBtn.SetActive(false);
        }
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void NextlevelBtnClicked1()
    {
        SceneManager.LoadScene(3);
    }


    //IEnumerator Pressed()
    //{
    //    //Fuel .fillAmount -= 0.1f;
    //    //SetMotorTorque(motorForce);
    //    //yield return new waitforseconds(2);
    //    //print("boost left : " + boostBar.fillAmount)
    //    if (image .fillAmount <= 0)
    //    { BreakBtnClicked(); }

    //}








}

//fronttyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
//backtyre.AddTorque(-movement * speed * Time.fixedDeltaTime);
//CarRigidbody.AddTorque(-movement * Torque * Time.fixedDeltaTime);


