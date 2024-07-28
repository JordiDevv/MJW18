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

    [FormerlySerializedAs("client")] public List<GameObject> clients;
    public Transform spawnPoint;

    public GameObject pizza;
    public Transform spawnPointPizza;

    public List<string> menu;

    public static GameManager Instance;

    public Text timeText;

    internal bool OrderTaken { get; set; }

    public int menuItemsCounter; //contador de items colocados en el menu

    int scoreService = 50;
    [SerializeField] TMPro.TextMeshProUGUI starsText;

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
        //comenzamos con que el jugador esta jugando
        playerIsPlaying = false;

        LoopGame();
    }

    void Update()
    {
        if (Time.time > 120)
        {
            Debug.Log("SE ACABO EL TIEMPO");
            //TODO: se acabo el tiempo pasar a pantalla de resultados
            Time.timeScale = 0;
        }

        timeText.text = ((int)Time.time).ToString();
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
        }

        menuItemsCounter = 0;
        menu.Clear();

        starsText.text = scoreService.ToString();
    }
}