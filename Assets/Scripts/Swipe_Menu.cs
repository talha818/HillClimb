using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swipe_Menu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;

    public GameObject RedCar;

   


    // Start is called before the first frame update
    void Start()
    {
        RedCar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos .Length ; i++)
        {
            pos[i] = distance * i;
        }

        if (Input .GetMouseButton (0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos .Length ; i++)
            {
                if (scroll_pos <pos [i]+(distance / 2) && scroll_pos > pos [i ] - distance /2)
                 {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value,pos[i ], 0.1f);
                 }

            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - distance / 2)
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f),0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a !=i )
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }

        }

    }

    public void LevelClicked()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Leve2Clicked()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void Leve3Clicked()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void Leve4Clicked()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void Leve5Clicked()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }

    public void Leve6Clicked()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }












}
