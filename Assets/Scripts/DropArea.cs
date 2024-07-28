using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public List<GameObject> positionsParent;

    public void Reset()
    {
        foreach (var child in positionsParent.Where(child => child.transform.GetChild(0)))
        {
            Destroy(child.transform.GetChild(0).gameObject);
        }
    }
}