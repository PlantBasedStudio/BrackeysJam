using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOpenDoors : MonoBehaviour
{
    // Text to show press E. Change it when we have a E sprite
    [SerializeField]
    private TextMeshPro UseText;

    // Camera of the Player
    public Transform Camera;

    //Distance ray between door and player
    private float MaxUseDistance = 5f;

    // The layer to open doors
    [SerializeField]
    private LayerMask UseLayers;

    private bool ShowTheLockedWord = false;

    
    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen && door.IsUnlocked == true)
                {
                    door.Close();
                    FindObjectOfType<AudioManager>().Play("Close");
                }
                else if (!door.isOpen && door.IsUnlocked == true)
                {
                    door.Open(transform.position);
                    FindObjectOfType<AudioManager>().Play("Open");
                }
                else if (door.isOpen && door.IsUnlocked == false)
                {
                    StartCoroutine(showOpen());
                    ShowTheLockedWord = true;
                    FindObjectOfType<AudioManager>().Play("Lock");
                }
                else if (!door.isOpen && door.IsUnlocked == false)
                {
                    StartCoroutine(showOpen());
                    ShowTheLockedWord = true;
                    FindObjectOfType<AudioManager>().Play("Lock");
                }
            }
        }
    }


    public IEnumerator showOpen()
    {
        yield return new WaitForSeconds(2f);
        ShowTheLockedWord = false;
    }
    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) &&  (hit.collider.TryGetComponent<Door>(out Door door))) 
        {
            if (door.isOpen && ShowTheLockedWord == false)
            {
                UseText.SetText("Close \"E\"");
            }
            else if (!door.isOpen && ShowTheLockedWord == false)
            {
                UseText.SetText("Open \"E\"");
            }
            if (door.isOpen && ShowTheLockedWord == true)
            {
                UseText.SetText("Locked");
            }
            else if (!door.isOpen && ShowTheLockedWord == true)
            {
                UseText.SetText("Locked");
            }
            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnUse();
        }
                
    }
}
