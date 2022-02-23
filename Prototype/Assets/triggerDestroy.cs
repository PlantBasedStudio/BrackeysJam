using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDestroy : MonoBehaviour
{

    public GameObject objectToDestroy;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            
            Destroy(objectToDestroy);
        }
    }
}
