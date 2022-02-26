using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public static bool isActive = false;
    public Transform target;
    public GameObject Character;
    public Camera cam;

    public GameObject blood;
    public GameObject pill;


    private static int iteration = 0;
    void Start()
    {
        iteration = 0;
    }

    void Update()
    {
        // if monster is trigger by player looking at him
        if (isActive == true)
        {
            transform.LookAt(target);
            StartCoroutine(RushOnPlayer());
            if (iteration == 0)
            {
                PlayScare();
                iteration++;
            }
            
        }
        
       
    }

    IEnumerator RushOnPlayer()
    {


        
        

        transform.position = Vector3.Lerp(transform.position, target.position, 0.5f);
      
        FindObjectOfType<AudioManager>().Stop("FirstSong");
        FindObjectOfType<AudioManager>().Play("SecondSong");
        yield return new WaitForSeconds(0.1f);
       
        Teleport.canSpawn = false;
        Destroy(gameObject, 0.5f);
        yield break;
    }

    public void PlayScare()
    {
        FindObjectOfType<AudioManager>().Play("Damaged");
        pill.SetActive(true);
        blood.SetActive(false);
        return;
    }

    
}
