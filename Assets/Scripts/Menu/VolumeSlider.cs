using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = AudioManager.Volume;
    }

    void Update()
    {
        SetVolume();
    }

    private void SetVolume()
    {
        AudioManager.Volume = slider.value;
    }
}
