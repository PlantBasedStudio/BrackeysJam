using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrigger : MonoBehaviour
{
    public GameObject breakableWall;
    public GameObject trigger;


    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            breakableWall.SetActive(false);
            if (trigger.name == "Zone2Trigger")
            {
                LookAtPlayer.isActive = true;
            }
            

            Destroy(this, 3);
        }
    }
    
        
    
}
