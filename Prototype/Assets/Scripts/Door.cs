using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;
    [HideInInspector]
    private bool isRotatingDoor = true;
    [SerializeField]
    private float speed = 1f;

    private float RotationAmount = 90f;
    //private float forwardDirection = 0f;

    private Vector3 StartRotation;
    //private Vector3 Forward;

    private Coroutine AnimationCoroutine;

   [SerializeField]
    public bool IsUnlocked;

    public bool isInvicible = true;

    private GameObject player;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        //Forward = transform.right;
        player = FindObjectOfType<NewPlayerOpenDoors>().gameObject;
    }

    public void Open()
    {
        Vector3 playerPosition = player.transform.position;
        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            
            if (isRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationOpen());
                
                
                
            }
        }
    }


    private IEnumerator DoRotationOpen()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(transform.InverseTransformPoint(player.transform.position).z >= 0)
        {
            // Open to the player
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.eulerAngles.y - RotationAmount, 0));
        }
        else
        {
            // Open AWAY from the player
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.eulerAngles.y + RotationAmount, 0));
        }
        isOpen = true;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
        yield return new WaitForSeconds(5f);
        if(isOpen && isInvicible)
        {
            Close();
            FindObjectOfType<AudioManager>().Play("Close");
        }
        
    }


    public void Close()
    {
        if (isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);

            }
            if (isRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        isOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
}
