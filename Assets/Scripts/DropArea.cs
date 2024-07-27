using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public List<GameObject> positionsParent;

    public void Reset()
    {
        foreach (var child in positionsParent)
        {
            if (child.transform.GetChild(0))
            {
                Debug.Log("cccc");
                Destroy(child.transform.GetChild(0).gameObject);
            }
        }
    }
}