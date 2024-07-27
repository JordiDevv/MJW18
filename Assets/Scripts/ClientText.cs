using System;
using System.Collections;
using UnityEngine;

public class ClientText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;
    public string dialogueLines;
    [SerializeField] float charactersPerSecond = 10;

    void Awake()
    {
        dialogueText = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public IEnumerator TypeText(string line)
    {
        Debug.Log("Typing text");
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
    }
}