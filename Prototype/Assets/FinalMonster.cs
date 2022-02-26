using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMonster : MonoBehaviour
{
    public GameObject finalMonster;
    public GameObject normalWoman;
    public GameObject evilWoman;
    public GameObject Door;
    public Transform finalMonsterT;

    public Camera cam;
    public PlayerMovement move;

    public GameObject blackscreen;
    

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Character")
        {
            StartCoroutine(finalScene());
            FindObjectOfType<AudioManager>().Stop("Steps");

        }
    }


    public IEnumerator finalScene()
    {
        PlayerMovement.isok = false;
        FindObjectOfType<AudioManager>().Stop("Steps");
        
       
        CameraMovement.canMove = false;
        FindObjectOfType<AudioManager>().Play("finalsong");
        yield return new WaitForSeconds(4f);
        finalMonster.SetActive(true);
        move.enabled = false;
        
        FindObjectOfType<AudioManager>().Play("final");
        FindObjectOfType<AudioManager>().Stop("Steps");
        CameraMovement.canMove = false;
        //jouer un son monstre
       
        cam.transform.LookAt(finalMonsterT);
        Door.GetComponent<Door>().Open();
        yield return new WaitForSeconds(2f);
        normalWoman.SetActive(false);
        evilWoman.SetActive(true);
        
    
        yield return new WaitForSeconds(2f);
       
        finalMonster.transform.position = Vector3.Lerp(finalMonster.transform.position, cam.transform.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        blackscreen.SetActive(true);
        //Blackscreen
        yield return new WaitForSeconds(20f);
        FindObjectOfType<AudioManager>().Stop("finalsong");
        CameraMovement.canMove = true;
        PlayerMovement.isok = true;
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
