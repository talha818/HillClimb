using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public  GameObject SettingPanel;
    
 

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    




}
