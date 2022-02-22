using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScriptTrigger : MonoBehaviour
{

 
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            LookAtPlayer.isActive = true;

            Destroy(this, 3);
        }
    }
}
