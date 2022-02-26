using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    public GameObject lightPlayer;

    public void Take()
    {
        
        lightPlayer.SetActive(true);
        Destroy(gameObject);
    }
}
