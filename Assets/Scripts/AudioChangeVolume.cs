using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "MyExposedParam";

    public Slider slider;

    private void Awake()
    {
        // Use the attached Slider when one is not assigned manually.
        if (slider == null)
            slider = GetComponent<Slider>();
    }

    private void Start()
    {
        // Match the slider value with the current mixer value.
        SyncSliderWithMixer();
    }

    private void SyncSliderWithMixer()
    {
        if (slider == null || group == null)
            return;

        // Read the current exposed mixer parameter value.
        if (group.GetFloat(floatParam, out float currentValue))
        {
            slider.SetValueWithoutNotify(currentValue);
        }
    }

    public void ChangeValue(float f)
    {
        // Update the exposed mixer parameter from the slider.
        group.SetFloat(floatParam, f);
    }
}