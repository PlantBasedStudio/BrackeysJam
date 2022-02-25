using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    // reference to our player
    public CharacterController controller;
    public GameObject character;
    public float speed = 10f;
    //private bool PlayMode = false;

    public AudioSource PlayerSource;
    public AudioClip StepSound;


    public float gravity = -18f;

    Vector3 velocity;
    
    void Start()
    {
        PlayerSource.clip = StepSound;
        
    }

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            if (!PlayerSource.isPlaying)
            {
               PlayerSource.Play();
            }
        }
        else
        {
            // Always stop the audio if the player is not inputting movement.
            PlayerSource.Stop();
        }


        //Gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

   
    
    
}
