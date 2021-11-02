using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound_Slider : MonoBehaviour
{
    [SerializeField] Slider VolumeSound;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs .HasKey ("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }


    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSound.value;
        Save();
    }
    

    public void Load()
    {
        VolumeSound.value = PlayerPrefs.GetFloat("musicvolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicvolume", VolumeSound .value );
    }
}
