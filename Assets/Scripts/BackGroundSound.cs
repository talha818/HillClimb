using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    private static BackGroundSound backgroundsound;

    private void Awake()
    {
        if (backgroundsound == null)
        {
            backgroundsound = this;
            //DontDestroyOnLoad(backgroundsound);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
