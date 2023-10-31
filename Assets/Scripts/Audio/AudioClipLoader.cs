using System;
using UnityEngine;

public class AudioClipLoader : MonoBehaviour
{
    [Header("CLIP")]
    [SerializeField] private AudioClip clip;

    [Header("AUDIO SOURCE")]

    [Header("By component")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("By tag")]
    [SerializeField] private string audioSourceTag;

    private void Start()
    {
        if (audioSource == null)
        {
            try
            {
                audioSource = GameObject.FindGameObjectWithTag(audioSourceTag).GetComponent<AudioSource>();
            }
            catch (Exception)
            {
                Debug.Log($"{gameObject.name}: AudioSource with tag {audioSourceTag} not found");
            }
        }

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
