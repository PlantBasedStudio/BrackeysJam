using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public static bool isActive = false;
    public Transform target;
    public GameObject Character;
    
    void Start()
    {
        
    }

    void Update()
    {
        // if monster is trigger by player looking at him
        if (isActive == true)
        {
            transform.LookAt(target);
            StartCoroutine(RushOnPlayer());
        }
        
       
    }

    IEnumerator RushOnPlayer()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        FindObjectOfType<AudioManager>().Stop("FirstSong");
        FindObjectOfType<AudioManager>().Play("SecondSong");
        yield return new WaitForSeconds(0.5f);
        Teleport.canSpawn = false;
        Destroy(gameObject, 1f);
    }

    
}
