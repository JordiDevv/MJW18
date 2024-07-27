using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //controla si el jugador esta jugando 
    public bool playerIsPlaying;

    public GameObject client;
    public Transform spawnPoint;

    public GameObject pizza;
    public Transform spawnPointPizza;

    public List<string> menu;

    public static GameManager Instance;

    internal bool OrderTaken { get; set; }

    public int menuItemsCounter; //contador de items colocados en el menu

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
        Instantiate(client, spawnPoint);
    }

    /// <summary>
    /// Acciones que se realizan al terminar de completar el menu
    /// </summary>
    public void ResetActions()
    {
        Debug.Log("bbbb");
        GameObject dropArea = GameObject.FindGameObjectWithTag("MENU");
        GameObject pizza = GameObject.FindGameObjectWithTag("PIZZA");

        dropArea.GetComponent<DropArea>().Reset();
        Destroy(client,.5f);
        Destroy(pizza);

        menuItemsCounter = 0;
        menu.Clear();

        playerIsPlaying = false;
        
        LoopGame();
    }
}