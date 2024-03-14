using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void again()
    {
        SceneManager.LoadScene("Start");
    }
    public void play()
    {
        SceneManager.LoadScene("Play");
    }
    public void howtoplay()
    {
        SceneManager.LoadScene("Howtoplay");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
