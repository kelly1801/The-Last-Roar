using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicAudio : Audio
{
    private static readonly UnityEvent volumeChanged = new();

    #region publicstaticproperties
    public static float Volume
    {
        get => PlayerPrefs.GetFloat(nameof(MusicAudio), 0.1f);
        set
        {
            PlayerPrefs.SetFloat(nameof(MusicAudio), value);
            volumeChanged?.Invoke();
        }
    }
    #endregion

    #region protectedmethods
    protected override void SetVolume()
    {
        this.audioSource.volume = Volume * this.multiplier;
    }
    #endregion

    #region privatemethods
    private new void Start()
    {
        base.Start();

        volumeChanged.AddListener(SetVolume);

        SetVolume();
    }
    #endregion
}