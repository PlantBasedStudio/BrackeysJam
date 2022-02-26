using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuSong");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop("MenuSong");
        FindObjectOfType<AudioManager>().Play("Light");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("FirstSong");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
