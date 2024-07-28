using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

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

    internal bool OrderTaken { get; set; }

    public int menuItemsCounter; //contador de items colocados en el menu
    int scoreService = 50;

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

        menuItemsCounter = 0;
        menu.Clear();

        playerIsPlaying = false;

        LoopGame();
    }

    public void Satisfy(List<string> hate)
    {
        foreach (var item in from item in menu from aaa in hate.Where(aaa => item.Contains(aaa)) select item)
        {
            scoreService -= 5;
        }
    }
}