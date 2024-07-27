using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;

    private void Start()
    {
        // Establece los sliders con los valores actuales
        musicSlider.value = SoundManager.instance.musicSource.volume;
        effectsSlider.value = SoundManager.instance.effectsSource.volume;

        // Añade listeners para cuando los valores cambien
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    public void SetMusicVolume(float volume)
    {
        SoundManager.instance.SetMusicVolume(volume);
    }

    public void SetEffectsVolume(float volume)
    {
        SoundManager.instance.SetEffectsVolume(volume);
    }
}