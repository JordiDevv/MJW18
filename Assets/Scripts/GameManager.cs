using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Hacemos el singleton
    public static GameManager Instance;

    public void Awake() {
        if (Instance == null) {
            Instance = GetComponent<GameManager>();
        }
    }

    void Start()
    {

        
    }

    void Update()
    {

    }
}
