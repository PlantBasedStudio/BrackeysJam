using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public static bool isActive = false;
    public Transform target;
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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {


            PlayerMovement.PlusOneSleepCycle();
           


        }
    }
}
