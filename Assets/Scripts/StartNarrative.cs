using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNarrative : MonoBehaviour
{
    [SerializeField] private GameObject narrativePanel;
    [SerializeField] private GameObject firstChat;
    [SerializeField] private GameObject secondChat;
    [SerializeField] private GameObject bossImage;
    [SerializeField] private GameObject meImage;
    public string sceneName;
    public int timeStart;
    public int timeChat1In;
    public int timeChat2In;
    public int timeChat1Out;
    public int timeChat2Out;
    public int timeMeImageIn;
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
        bossImage.SetActive(true);
        yield return new WaitForSeconds(timeChat1In);
        firstChat.SetActive(true);
        yield return new WaitForSeconds(timeMeImageIn);
        meImage.SetActive(true);
        yield return new WaitForSeconds(timeChat2In);
        secondChat.SetActive(true);
        yield return new WaitForSeconds(timeChat1Out);
        firstChat.SetActive(false);
        bossImage.SetActive(false);
        yield return new WaitForSeconds(timeChat2Out);
        secondChat.SetActive(false);
        meImage.SetActive(false);
        yield return new WaitForSeconds(timeOut);
        SceneManager.LoadScene(sceneName);
    }
}
