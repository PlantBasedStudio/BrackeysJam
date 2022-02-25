using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSound : MonoBehaviour
{
    public GameObject SubtilesObj;
    public Text subtiles;
    public string subtilesText;

    public string sound;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {

            FindObjectOfType<AudioManager>().Play(sound);
            StartCoroutine(SubtilesModeOn(subtilesText));
           
           
        }
    }

    public IEnumerator SubtilesModeOn(string subtilesText)
    {
        subtiles.text = subtilesText;
        SubtilesObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SubtilesObj.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}

