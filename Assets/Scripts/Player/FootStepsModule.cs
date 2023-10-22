using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class FootStepsModule : MonoBehaviour
{
    [SerializeField] AudioClip[] walkingfootStepSounds;
    [SerializeField] AudioClip[] runningfootStepSounds;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
         
    }

    void PlayFootStepSounds()
    {
        AudioClip clip = walkingfootStepSounds[Random.Range(0, walkingfootStepSounds.Length)];
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log(clip.name);
    }

    void PlayRunningFootStepSounds()
    {
        AudioClip clip = runningfootStepSounds[Random.Range(0, runningfootStepSounds.Length)];
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log(clip.name);
    }
}
