using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static readonly string VOLUME = "volume";
    
    private AudioManager instance;

    public static float Volume
    {
        get { return PlayerPrefs.GetFloat(VOLUME, 0.1f); }
        set { PlayerPrefs.SetFloat(VOLUME, value);}
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
