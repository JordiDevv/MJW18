using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;

    public static SoundController Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = GetComponent<SoundController>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

 

    public void PlayClip(AudioClip clip) {

        audioSource.PlayOneShot(clip);

    }


}
