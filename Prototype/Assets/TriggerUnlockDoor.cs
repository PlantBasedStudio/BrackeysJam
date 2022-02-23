using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUnlockDoor : MonoBehaviour
{

    [SerializeField]
    private GameObject door;

    public Door Door;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {

            Door.IsUnlocked = true;

            Destroy(this, 3);
        }
    }
}
