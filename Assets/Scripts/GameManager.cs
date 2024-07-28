using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //controla si el jugador esta jugando 
    public bool playerIsPlaying;
    public float gameplayDuration;
    [FormerlySerializedAs("client")] public List<GameObject> clients;
    public Transform spawnPoint;

    public GameObject pizza;
    public Transform spawnPointPizza;

    public List<string> menu;

    public static GameManager Instance;

    public Text timeText;
    private float startTime = -37f;

    public GameObject GameOverMenu;
    internal bool OrderTaken { get; set; }

    public int menuItemsCounter; //contador de items colocados en el menu

    [SerializeField]
    float scoreService = 50;

    int maxScore = 50;



    public float maxDuration =120;
    float currentTime;


    [SerializeField] TMPro.TextMeshProUGUI starsText;


    public Image scoreImage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<GameManager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //comenzamos con que el jugador no esta jugando
        playerIsPlaying = false;
        GameOverMenu.SetActive(false);

        //start with the max amount
        scoreImage.fillAmount = maxScore;
        
        LoopGame();

        currentTime = maxDuration;
        timeText.text = currentTime.ToString();
    }

    void Update()
    {
        //if (Time.time > gameplayDuration)
        //{
        //    Debug.Log("SE ACABO EL TIEMPO");
        //    //TODO: se acabo el tiempo pasar a pantalla de resultados
        //    Time.timeScale = 0;
        //    GameOverMenu.SetActive(true);
        //}

        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
        } else {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }

        int castedCurrentTime = (int)currentTime;

        timeText.text = castedCurrentTime.ToString();
    }

    void LoopGame()
    {
        SpawnClient();
        SpawnPizza();
    }

    void SpawnPizza()
    {
        Instantiate(pizza, spawnPointPizza);
    }

    void SpawnClient()
    {
        Instantiate(clients[Random.Range(0, clients.Count)], spawnPoint);
    }

    /// <summary>
    /// Acciones que se realizan al terminar de completar el menu
    /// </summary>
    public void ResetActions()
    {
        GameObject dropArea = GameObject.FindGameObjectWithTag("MENU");
        GameObject pizza = GameObject.FindGameObjectWithTag("PIZZA");

        dropArea.GetComponent<DropArea>().Reset();
        Destroy(pizza);

        playerIsPlaying = false;

        LoopGame();
    }

    public void Satisfy(List<string> hate)
    {
        if (hate.Any(item => menu.Contains(item)))
        {
            scoreService -= 5;
            Debug.Log(scoreService);
        }

        menuItemsCounter = 0;
        menu.Clear();

        //starsText.text = scoreService.ToString();
        UpdateScoreUI();
    }

    /// <summary>
    /// Actualiza la UI del score
    /// </summary>
    void UpdateScoreUI() {

        scoreImage.fillAmount = scoreService /maxScore;
    }
}