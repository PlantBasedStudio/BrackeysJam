using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField]
    private GameObject door;

    public Door Door;
    public GameObject triggerToDoor;
    public void Take()
    {
        Door.IsUnlocked = true;
        triggerToDoor.SetActive(true);
        Destroy(gameObject);
    }
}
