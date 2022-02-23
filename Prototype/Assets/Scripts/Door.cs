using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    public bool isOpen = false;
    [SerializeField]
    private bool isRotatingDoor = true;
    [SerializeField]
    private float speed = 1f;

    private float RotationAmount = 90f;
    private float forwardDirection = 0f;

    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

   [SerializeField]
    public bool IsUnlocked;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        Forward = transform.right;
    }

    public void Open(Vector3 PlayerPosition)
    {
        PlayerPosition = player.transform.position;
        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            
            if (isRotatingDoor)
            {
                float dot = Vector3.Dot(Forward, (PlayerPosition - transform.position).normalized);
                Debug.Log($"Dot: { dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }
    }


    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(ForwardAmount >= forwardDirection)
        {
            // Open to the player
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - RotationAmount, 0));
        }
        else
        {
            // Open AWAY from the player
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + RotationAmount, 0));
        }
        isOpen = true;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
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
