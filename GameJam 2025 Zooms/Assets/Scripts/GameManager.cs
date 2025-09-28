using System;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //Will load the appropriate scene when it exists later
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        //Will load the appropriate scene when it exists later
        SceneManager.LoadScene(1);
    }

    public void BacktoTitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
