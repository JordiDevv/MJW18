using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{


    public List<GameObject> positionsParent;

    private List<GameObject> children;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Reset();
        }
    }
    private void Reset() {
        foreach (var child in positionsParent) {

          
            Object.Destroy(child.transform.GetChild(0).gameObject);
    

        }



    }


}
