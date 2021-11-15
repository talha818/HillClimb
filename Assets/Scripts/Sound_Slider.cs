using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound_Slider : MonoBehaviour
{
    public AudioSource Audiosourceslider;
    private float musicvolume=1f;

    public Slider volSlider;

    // Start is called before the first frame update
    void Start()
    {
        Audiosourceslider.Play();
    }

    void Update()
    {
        Audiosourceslider.volume = musicvolume;
    }

    public void slideVolume()
    {
        musicvolume = volSlider.value;
    }
    

    
}
