using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{

    public float rotateSpeed;
    public float floatFrequency, floatAmplitude;
    public Vector3 startPos;


    void Awake()
    {
        startPos = transform.position;
    }
    public void Take()
    {
        FindObjectOfType<AudioManager>().Play("Pills");
        Destroy(gameObject);
    }

    void Update()
    {
        
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitude;

        transform.position = tempPos;
    }
}

