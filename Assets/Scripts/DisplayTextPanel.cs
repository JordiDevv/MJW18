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
        textPanel.SetActive(true);
    }

    void HideText()
    {
        textPanel.SetActive(false);
        IsSpeaking = false;
    }

}