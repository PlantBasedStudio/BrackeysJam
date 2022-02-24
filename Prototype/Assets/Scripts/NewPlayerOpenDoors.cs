using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewPlayerOpenDoors : MonoBehaviour
{

    // Text to show press E. Change it when we have a E sprite
    [SerializeField]
    private TextMeshPro useText;


    // The layer to open doors
    [SerializeField]
    private LayerMask useLayers;



    // Camera of the Player
    Transform mainCamera;
    //  The audio Manager
    AudioManager audioManager;
    


    //  Distance ray between door and player
    private float maxUseDistance = 3f;
    private bool showTheLockedWord = false;


    private void Start()
    {
        mainCamera = Camera.main.transform;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {

        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hit, maxUseDistance, useLayers) && (hit.collider.TryGetComponent<Door>(out Door door)))
        {


            /**
             * This is a ternary Operator
             * If "showTheLockedWord" is true, the text to display is simply "Locked"
             * if not, we ask, "is the door open?". If yes, the text is "Close"
             * if the door is not open, the text is "Open"
             */
            string textToDisplay = showTheLockedWord ? "Locked" :
                                   door.isOpen ? "Close \"E\"" :
                                   "Open \"E\"";
            useText.SetText(textToDisplay);

            useText.gameObject.SetActive(true);
            useText.transform.position = hit.point - (hit.point - mainCamera.position).normalized * 0.01f;
            useText.transform.rotation = Quaternion.LookRotation((hit.point - mainCamera.position).normalized);

            /**
            if (door.isOpen && showTheLockedWord == false)
            {
                useText.SetText("Close \"E\"");
            }
            else if (!door.isOpen && showTheLockedWord == false)
            {
                useText.SetText("Open \"E\"");
            }
            if (door.isOpen && showTheLockedWord == true)
            {
                useText.SetText("Locked");
            }
            else if (!door.isOpen && showTheLockedWord == true)
            {
                useText.SetText("Locked");
            } */ // Legacy


            if (Input.GetKeyDown(KeyCode.E)) //We check for the E if the Raycast hits, not every frame
            {
                OnUse(door);

            }

        }
        else
        {
            useText.gameObject.SetActive(false);
        }

    }

    public void OnUse(Door door)
    {

        /**
         if (door.isOpen && door.IsUnlocked)
        {
            door.Close();
            FindObjectOfType<AudioManager>().Play("Close");
        }
        else if (!door.isOpen && door.IsUnlocked)
        {
            door.Open(transform.position);
            FindObjectOfType<AudioManager>().Play("Open");
        }
        else if (door.isOpen && !door.IsUnlocked)
        {
            StartCoroutine(showOpen());
            showTheLockedWord = true;
            FindObjectOfType<AudioManager>().Play("Lock");
        }
        else if (!door.isOpen && !door.IsUnlocked)
        {
            StartCoroutine(showOpen());
            showTheLockedWord = true;
            FindObjectOfType<AudioManager>().Play("Lock");
        }
         */ // Legacy


        if (!door.IsUnlocked) // If locked
        {
            StartCoroutine(showOpen());
            showTheLockedWord = true;
            audioManager.Play("Lock");
        }
        else
        {
            if (door.isOpen)
            {
                door.Close();
                audioManager.Play("Close");
            }
            else
            {
                door.Open();
                audioManager.Play("Open");
            }
        }


    }


    public IEnumerator showOpen()
    {
        yield return new WaitForSeconds(2f);
        showTheLockedWord = false;
    }


}
