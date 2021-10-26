using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_manager : MonoBehaviour
{
    [SerializeField] Image Sound_On;
    [SerializeField] Image Sound_Off;
    private bool muted = false;


    // Start is called before the first frame update
    void Start()
    {
      if (!PlayerPrefs .HasKey("muted"))
        {
            PlayerPrefs.GetInt("muted", 0);
            Load();
        }
      else
        {
            Load();
        }

        UpdateBtnIcon();
        AudioListener.pause = muted;
        
    }


    private void UpdateBtnIcon()
    {
        if(muted ==false )
        {
            Sound_On.enabled = true;
            Sound_Off.enabled = false;
        }
        else
        {
            Sound_On.enabled = false;
            Sound_Off.enabled = true;


        }
    }

    public void SoundBtnClicked()
    {
        if(muted ==false )
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateBtnIcon();
    }

    private void Load()
    {
       muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
