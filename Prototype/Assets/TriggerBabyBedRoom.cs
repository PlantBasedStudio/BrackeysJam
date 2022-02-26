using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBabyBedRoom : MonoBehaviour
{

    public GameObject Door;
    public GameObject Monster3;
    public Transform Target;
    public Camera cam;
    public PlayerMovement move;
    public TriggerSound trigger;
    public GameObject triggerSoundActive;
    public GameObject triggerSoundActive2;
    public GameObject triggerSoundActive3;
    public GameObject monster4;
    public GameObject blockDoor;
    public GameObject pills2;

    public GameObject blood2;
    public GameObject[] lightss;
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {

            FindObjectOfType<AudioManager>().Play("BabyRoomSong");
            FindObjectOfType<AudioManager>().Stop("SecondSong");
            FindObjectOfType<AudioManager>().Stop("Steps");
            blood2.SetActive(true);
            pills2.SetActive(true);
            monster4.SetActive(true);
            triggerSoundActive.SetActive(true);
            triggerSoundActive2.SetActive(true);
            triggerSoundActive3.SetActive(true);
            foreach (GameObject lightss in lightss)
            {
                lightss.SetActive(false);
            }
                blockDoor.GetComponent<Door>().IsUnlocked = false;
            StartCoroutine(BabyRoomEvent());
            FindObjectOfType<AudioManager>().Play("NO");
            StartCoroutine(trigger.SubtilesModeOn("Aana No!"));
            
        }
    }


    public IEnumerator BabyRoomEvent()
    {
        move.enabled = false;
        CameraMovement.canMove = false;
        Door.GetComponent<Door>().Open();
        Door.GetComponent<Door>().IsUnlocked = true;
        yield return new WaitForSeconds(0.1f);
        cam.transform.LookAt(Target);
        Monster3.SetActive(true);
        // PLay voiceline Aana laught
        yield return new WaitForSeconds(4f);
        Door.GetComponent<Door>().Close();
        yield return new WaitForSeconds(2f);
        move.enabled = true;
        CameraMovement.canMove = true;
        Monster3.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
