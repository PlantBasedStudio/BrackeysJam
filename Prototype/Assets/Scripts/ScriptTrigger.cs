using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrigger : MonoBehaviour
{
    public GameObject breakableWall;
    public GameObject trigger;
    public GameObject invisibleDoor;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            breakableWall.SetActive(false);
            invisibleDoor.SetActive(true);

            Destroy(this, 3);
        }
    }
        
    
}
