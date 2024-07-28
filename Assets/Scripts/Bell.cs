using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public AudioClip ring;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void OnMouseDown() {
        GameManager.Instance.ResetActions();
        GameManager.Instance.OrderTaken = true;

        SoundController.Instance.PlayClip(ring);
    }
}
