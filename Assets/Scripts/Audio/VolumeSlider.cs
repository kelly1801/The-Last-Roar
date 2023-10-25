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
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        SetVolume();
    }

    private void SetVolume()
    {
        AudioManager.Volume = slider.value;
    }
}