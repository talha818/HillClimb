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


    private float movement = 0f;
    private float rotaion = 0f;

    private bool Ispressed;

    public float Fuel = 1f;
    public float FuelConsumption = 0.5f;
    public Image FuelImage;


    public GameObject PausePanel;

    public GameObject PauseBtn;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public GameObject FuelLowPanel;

    public AudioSource GameSound;
    public AudioClip FuelClip;

    public AudioClip Gameoverclip;

    public AudioClip Winclip;

    public Text FuelHighScore;
    public Text GameOverHighScore;


    private IEnumerator coroutine;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        FuelImage.fillAmount = Fuel;

        if (Ispressed)
        {
            movement = -1 * speed;
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
        coroutine = FuelPanelClicked();

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
        if (Fuel < 0)
        {
            BreakBtnClicked();
            StartCoroutine(coroutine);
            //FuelLowPanelClicked();
            //Time.timeScale = 0f;
            //OpenParachute();
        }

        //Fuel -= FuelConsumption * Time.fixedDeltaTime;


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
            GameSound.PlayOneShot(Winclip);
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

    public void ReplayBtnClickedLevel3()
    {
        SceneManager.LoadScene(4);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReplayBtnClickedLevel4()
    {
        SceneManager.LoadScene(5);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReplayBtnClickedLevel5()
    {
        SceneManager.LoadScene(6);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReplayBtnClickedLevel6()
    {
        SceneManager.LoadScene(7);
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
        coindel.ShowHighScore();
        coindel.SaveHighscore();
        GameOverHighScore .text ="HIGHSCORE "+ coindel.HighScore.ToString();
        Time.timeScale = 0;
    }

    //public void FuelLowPanelClicked()
    //{
    //    if (FuelLowPanel == true)
    //    {
    //        PauseBtn.SetActive(false);
    //    }
    //    FuelLowPanel .SetActive(true);
    //    Time.timeScale = 0;
    //}


    public void NextlevelBtnClicked1()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }


    public void NextlevelBtnClicked2()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void NextlevelBtnClicked3()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }


    public void NextlevelBtnClicked4()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }

    public void NextlevelBtnClicked5()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }

    public void NextlevelBtnClicked6()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }



    private IEnumerator FuelPanelClicked()
    {
        yield return new WaitForSeconds(2f);
        if (FuelLowPanel == true)
        {
            PauseBtn.SetActive(false);
        }
        FuelLowPanel.SetActive(true);
        coindel.ShowHighScore();
        coindel.SaveHighscore();
        Time.timeScale = 0;
        Debug.Log("aa");
        FuelHighScore .text = "HIGHSCORE "+ coindel.HighScore.ToString();
    }


}









