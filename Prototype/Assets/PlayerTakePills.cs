using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTakePills : MonoBehaviour
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

    private static int pillsCount = 0;
    public GameObject Cam;
    public float timeToReachTarget = 45;
    public float t = 0f;
    public TriggerSound solo;
    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Pills>(out Pills pills))
            {
                pillsCount++;
                pills.Take();
                if(pillsCount >= 2)
                {
                    FindObjectOfType<AudioManager>().Play("OhMy");
                    StartCoroutine(Wait(2f));


                }

            }
        }
    }
    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) && (hit.collider.name.Equals("Pill")))
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

        if(pillsCount >= 2)
        {
            t += Time.deltaTime / timeToReachTarget;
            Cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(Cam.GetComponent<Camera>().fieldOfView, 75, t);
        }

    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(solo.SubtilesModeOn("Oh my head"));
    }
}
