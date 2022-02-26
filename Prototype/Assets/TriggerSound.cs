using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSound : MonoBehaviour
{

    public string sound;
    

    public string sub;
    public GameObject subtilesObj;
    public Text subtilestext;


    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {

            FindObjectOfType<AudioManager>().Play(sound);
            StartCoroutine(SubtilesModeOn(sub));


        }
    }

    public IEnumerator SubtilesModeOn(string sub)
    {
        subtilestext.text = sub;
        subtilesObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        subtilesObj.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}