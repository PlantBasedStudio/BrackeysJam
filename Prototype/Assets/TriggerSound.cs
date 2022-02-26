using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{

    public string sound;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {

            FindObjectOfType<AudioManager>().Play(sound);
            Destroy(this, 0.1f);
           
        }
    }
}

