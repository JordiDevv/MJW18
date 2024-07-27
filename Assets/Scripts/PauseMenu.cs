using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsMenuPanel;
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;

    private void Start()
    {
        // Inicializar sliders con los valores actuales del SoundManager
        if (SoundManager.instance != null)
        {
            float musicVolume;
            SoundManager.instance.musicMixerGroup.audioMixer.GetFloat("MusicVolume", out musicVolume);
            musicVolumeSlider.value = Mathf.Pow(10, musicVolume / 20);

            float effectsVolume;
            SoundManager.instance.effectsMixerGroup.audioMixer.GetFloat("EffectsVolume", out effectsVolume);
            effectsVolumeSlider.value = Mathf.Pow(10, effectsVolume / 20);

            // Añadir listeners para los cambios en los sliders
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
            effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuPanel.activeSelf)
            {
                CloseOptions();
            }
            else
            {
                TogglePauseMenu();
            }
        }
    }

    public void ResumeGame()
    {
        TogglePauseMenu();
    }

    public void OpenOptions()
    {
        pausePanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenuPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void QuitGamePause()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void TogglePauseMenu()
    {
        bool isPaused = !pausePanel.activeSelf;
        pausePanel.SetActive(isPaused);
        //Time.timeScale = isPaused ? 0f : 1f;
    }

    public void SetMusicVolume(float volume)
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.SetMusicVolume(volume);
        }
    }

    public void SetEffectsVolume(float volume)
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.SetEffectsVolume(volume);
        }
    }
}
