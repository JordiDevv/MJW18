using System;
using System.Collections;
using UnityEngine;

public class DisplayTextPanel : MonoBehaviour
{
    [SerializeField] GameObject textPanel;
    float speakSpeed;
    Rect rectTransform;
    bool IsSpeaking { get; set; } = true;

    void Awake()
    {
        textPanel = gameObject;
        rectTransform = gameObject.GetComponent<RectTransform>().rect;
    }
    
    void Start()
    {
        if (IsSpeaking) StartCoroutine(Speak());
    }

    IEnumerator Speak()
    {
        DisplayText();
        yield return new WaitForSeconds(10f);
        HideText();
    }

    void DisplayText()
    {
        MoveDown();
        textPanel.SetActive(true);
    }

    void HideText()
    {
        MoveUp();
        textPanel.SetActive(false);
        IsSpeaking = false;
    }

    void MoveDown() => textPanel.transform.position = new Vector3(textPanel.transform.position.x, textPanel.transform.position.y - rectTransform.height - 20, textPanel.transform.position.z);
    void MoveUp() => textPanel.transform.position = new Vector3(textPanel.transform.position.x, textPanel.transform.position.y + rectTransform.height + 20, textPanel.transform.position.z);
}