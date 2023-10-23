using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static readonly string VOLUME = "volume";

    private AudioManager instance;
    private List<AudioSource> audioSources;

    public static float Volume
    {
        get { return PlayerPrefs.GetFloat(VOLUME, 0.1f); }
        set { PlayerPrefs.SetFloat(VOLUME, value); }
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

    private void Start()
    {
        audioSources = new();

        GameObject[] audioSourcesObjects = GameObject.FindGameObjectsWithTag("AudioSource");

        foreach (GameObject audioSourceObject in audioSourcesObjects)
        {
            audioSources.Add(audioSourceObject.GetComponent<AudioSource>());
        }
    }

    private void FixedUpdate()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = Volume;
        }
    }
}
