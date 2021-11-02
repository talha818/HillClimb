using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coindel : MonoBehaviour
{

    public AudioSource CoinSound;
    public AudioClip clip;


    public int Score;
    public TextMeshProUGUI Scoretxt;


    private void Start()
    {
        Score = 0;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Coin5")
        {
            Score+=5;
            Scoretxt.text = "X " + Score.ToString();
            CoinSound.PlayOneShot(clip);
            


            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin25")
        {
            Score += 25;
            Scoretxt.text = "X " + Score.ToString();
            CoinSound.PlayOneShot(clip);




            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin100")
        {
            Score += 100;
            Scoretxt.text = "X " + Score.ToString();
            CoinSound.PlayOneShot(clip);



            Destroy(c.gameObject);
        }


        if (c.gameObject.tag == "Coin500")
        {
            Score += 500;
            Scoretxt.text = "X " + Score.ToString();
            CoinSound.PlayOneShot(clip);



            Destroy(c.gameObject);
        }
    }
}
