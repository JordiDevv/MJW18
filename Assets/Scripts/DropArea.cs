using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{


    public List<GameObject> positionsParent;

    public void Reset() {
        foreach (var child in positionsParent) {
            Debug.Log("cccc");
            Destroy(child.transform.GetChild(0).gameObject);
        }



    }


}
