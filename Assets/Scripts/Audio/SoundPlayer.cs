using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundPlayer : MonoBehaviour
{
    private Button button;

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

        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Play);
    }

    private void Play()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip, AudioManager.Volume);
        }
    }
}
