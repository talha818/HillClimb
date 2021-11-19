using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coindel : MonoBehaviour
{

    public AudioSource CoinSound;
    public AudioClip Coinclip;
    

    public static int Score;
    public Text  Scoretxt;

    public static int HighScore;
    public Text HighScoretxt;
    public static int hiScore;


    private void Start()
    {
        Score = 0;
        GetHighScore();
    }


    private void Update()
    {
        if(Score>HighScore )
        {
            HighScore = Score;
        }

        HighScoretxt.text = "HIGHSCORE  " + hiScore.ToString();

        //Debug.Log(HighScore + " -- " + hiScore);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Coin5")
        {
            Score+=5;
            Scoretxt.text = "Score: " + Score.ToString();
            CoinSound.PlayOneShot(Coinclip);
            


            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin25")
        {
            Score += 25;
            Scoretxt.text = "Score: " + Score.ToString();
            CoinSound.PlayOneShot(Coinclip);




            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin100")
        {
            Score += 100;
            Scoretxt.text = "Score: " + Score.ToString();
            CoinSound.PlayOneShot(Coinclip);



            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin500")
        {
            Score += 500;
            Scoretxt.text = "Score: " + Score.ToString();
            CoinSound.PlayOneShot(Coinclip);



            Destroy(c.gameObject);
        }

        
    }

    public static void SaveHighscore()
    {
       
       PlayerPrefs.SetInt("HighScore", HighScore);
        Debug.Log("hi score :" + HighScore);
    }

    public void GetHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    public static void ShowHighScore()
    {
        hiScore = HighScore;
    }

    
}
