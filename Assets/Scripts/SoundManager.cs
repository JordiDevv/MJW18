using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource; 
    
    public static SoundManager instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;

    public AudioClip backgroundMusic;
    public AudioClip introMusic;
    public AudioClip buttonClickSound;

    public AudioMixerGroup musicMixerGroup;
    public AudioMixerGroup effectsMixerGroup;

    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;

    private float previousMusicVolume = 1f;
    private float previousEffectsVolume = 1f;

    private void Awake()
    {
        // Asegurarse de que solo haya un SoundManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InitializeVolumeSettings();
    }

    private void InitializeVolumeSettings()
    {
        SetMusicVolume(previousMusicVolume);
        SetEffectsVolume(previousEffectsVolume);
    }

    public void PlayEffect(AudioClip clip)
    {
        effectsSource.outputAudioMixerGroup = effectsMixerGroup;
        effectsSource.PlayOneShot(clip);
    }

    public void StopMusic(AudioClip clip)
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        float dbVolume = (volume > 0.0001f) ? Mathf.Log10(volume) * 20 : -80f;
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", dbVolume);
        
    }

    public void SetEffectsVolume(float volume)
    {
        float dbVolume = (volume > 0.0001f) ? Mathf.Log10(volume) * 20 : -80f;
        effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", dbVolume);
    }

    public void PlayButtonClickSound()
    {
        PlayEffect(buttonClickSound);
    }
}
