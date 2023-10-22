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

    void PlayFootStepSounds() // Usado en el modulo de animation como eventos.
    {
        AudioClip clip = walkingfootStepSounds[Random.Range(0, walkingfootStepSounds.Length)];
        audioSource.pitch = .8f;
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log(clip.name);
    }

    void PlayRunningFootStepSounds()
    {
        AudioClip clip = runningfootStepSounds[Random.Range(0, runningfootStepSounds.Length)];
        audioSource.pitch = 1.0f;
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log(clip.name);
    }
}
