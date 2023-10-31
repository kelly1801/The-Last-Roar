using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SoundAudio : Audio
{
    private static readonly UnityEvent volumeChanged = new();

    #region publicstaticproperties
    public static float Volume
    {
        get => PlayerPrefs.GetFloat(nameof(SoundAudio), 0.2f);
        set
        {
            PlayerPrefs.SetFloat(nameof(SoundAudio), value);
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