using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNarrative : MonoBehaviour
{
    [SerializeField] private GameObject narrativePanel;
    [SerializeField] private GameObject firstChat;
    [SerializeField] private GameObject secondChat;
    public string sceneName;
    public int timeStart;
    public int timeChat;
    public int timeOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(StartChat));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartChat()
    {
        narrativePanel.SetActive(true);
        yield return new WaitForSeconds(timeStart);
        firstChat.SetActive(true);
        yield return new WaitForSeconds(timeChat);
        secondChat.SetActive(true);
        yield return new WaitForSeconds(timeChat + 4);
        firstChat.SetActive(false);
        yield return new WaitForSeconds(timeChat - 2);
        secondChat.SetActive(false);
        yield return new WaitForSeconds(timeOut);
        SceneManager.LoadScene(sceneName);
    }
}
