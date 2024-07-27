using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //controla si el jugador esta jugando 
    public bool playerIsPlaying;

    public GameObject client; 
    public Transform spawnPoint;
    
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
}
