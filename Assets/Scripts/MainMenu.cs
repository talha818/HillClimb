using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public  GameObject SettingPanel;
    public Text hiScore;
    

    



    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        SettingPanel.SetActive(false);
       


        hiScore.text = "High Score :" + GetHighScore().ToString();
        Debug.Log(GetHighScore());
        if (GetHighScore() <= 0)
        {
            hiScore.text = "High Score : 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void SettingBtnClicked()
    {
        mainMenu.SetActive(false);
        SettingPanel.SetActive(true);
        
    }

    
    public void BackBtnClicked()
    {
        mainMenu.SetActive(true );
        SettingPanel.SetActive(false);
    }

    public void ExitBtnClicked()
    {
        Application.Quit();
    }


    int GetHighScore()
    {
        return  PlayerPrefs.GetInt("HighScore");
    }

}
