using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static readonly string VOLUME = "VOLUME";
    private static UnityEvent onVolumeChange;

    private AudioManager instance;
    private AudioSource audioSource;

    [SerializeField] private float volumeMultiplier = 1f;

    public static float Volume
    {
        get => PlayerPrefs.GetFloat(VOLUME, 0.1f);
        set
        {
            PlayerPrefs.SetFloat(VOLUME, value);
            onVolumeChange.Invoke();
        }
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
        audioSource = gameObject.GetComponent<AudioSource>();

        onVolumeChange = new UnityEvent();
        onVolumeChange.AddListener(OnVolumeChanged);

        SetVolume();
    }

    private void SetVolume()
    {
        audioSource.volume = Volume * volumeMultiplier;
    }

    private void OnVolumeChanged()
    {
        SetVolume();
    }
}
