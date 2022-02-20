using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to our player
    public CharacterController controller;

    public float speed = 10f;

    public static int sleepcycle = 1;
    public bool canTeleport = true;
    
    void Start()
    {
        sleepcycle = 1;
    }

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        if (sleepcycle >= 2 && canTeleport == true)
        {
            Teleport();
        }
    }

    public static void PlusOneSleepCycle()
    {
        sleepcycle++;
        Debug.Log(sleepcycle);
    }

    public void Teleport()
    {
        controller.gameObject.transform.position = new Vector3(0f, 1.35f, 0);
        canTeleport = false;
        sleepcycle = 1;
    }
    
}
