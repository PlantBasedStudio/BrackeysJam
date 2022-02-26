using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedWalking : MonoBehaviour
{
    public GameObject character;
   
    public Vector3 startPos;

    public int speed = -1;

    public void Awake()
    {
        startPos = character.transform.position;
    }
    public void Update()
    {
        if(character.activeSelf)
        {
            
            Vector3 tempPos = startPos;
            tempPos.x += Mathf.Lerp(startPos.x, startPos.x * speed, Time.deltaTime * 10000f);
            character.transform.position = tempPos;
        }
    }
}
