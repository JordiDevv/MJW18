using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //controla si el jugador esta jugando 
    public bool playerIsPlaying;

    public GameObject client;
    public Transform spawnPoint;

    public List<string> menu;

    public static GameManager Instance;

    public int menuItemsCounter; //contador de items colocados en el menu

    private void Awake() {
        if (Instance == null) {
            Instance = GetComponent<GameManager>();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //comenzamos con que el jugador esta jugando
        playerIsPlaying = false;

        SpawnClient();
    }

    // Update is called once per frame
    void Update()
    {
       



    }


    private void SpawnClient() {
        Instantiate(client, spawnPoint);
    
    }

    /// <summary>
    /// Acciones que se realizan al terminar de completar el menu
    /// </summary>
    public void ResetActions() {

        Debug.Log("bbbb");
        GameObject dropArea = GameObject.FindGameObjectWithTag("MENU");
        GameObject pizza = GameObject.FindGameObjectWithTag("PIZZA");

        dropArea.GetComponent<DropArea>().Reset();
        Destroy(pizza);
        
        menuItemsCounter = 0;
        menu.Clear();

    }
}
