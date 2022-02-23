using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTakeKey : MonoBehaviour
{

    // Text to show press E. Change it when we have a E sprite
    [SerializeField]
    private TextMeshPro UseText;

    // Camera of the Player
    public Transform Camera;

    //Distance ray between door and player
    private float MaxUseDistance = 3f;

    // The layer to take keys
    [SerializeField]
    private LayerMask UseLayers;

    


    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Key>(out Key key))
            {
                FindObjectOfType<AudioManager>().Play("Key");
                key.Take();
                
            }
        }
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) && (hit.collider.name.Equals("Key")))
        {
            Debug.Log("Press E");
            UseText.SetText("Take \"E\"");

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
