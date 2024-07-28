using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;



    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
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

    }

    public void CloseOptions()
    {

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
