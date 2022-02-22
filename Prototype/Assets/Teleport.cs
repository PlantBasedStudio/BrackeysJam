using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public CharacterController controller;
   
    [SerializeField]
    public GameObject player;


    public static bool canSpawn = true;
    public IEnumerator Respawn()
    {
        controller.enabled = false;
        yield return new WaitForSeconds(0.02f);
        player.transform.position = new Vector3(0f, 1.29f, 0);
        canSpawn = true;
        yield return new WaitForSeconds(0.02f);
       controller.enabled = true;
    }

    private void Update()
    {
        if (canSpawn == false)
        {
            StartCoroutine(Respawn());
        }
    }
}
