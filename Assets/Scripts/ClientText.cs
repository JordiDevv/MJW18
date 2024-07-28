using System;
using System.Collections;
using UnityEngine;

public class ClientText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;
    [SerializeField] float charactersPerSecond = 10;
    [SerializeField] AudioSource voice;
    [SerializeField] AudioClip voiceClip;

    void Awake()
    {
        dialogueText = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public IEnumerator TypeText(string line)
    {
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            voice.PlayOneShot(voiceClip);
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
    }
}