using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDestroy : MonoBehaviour
{

    public GameObject objectToDestroy;
    public GameObject pill;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            pill.SetActive(true);
            Destroy(objectToDestroy);
        }
    }
}
