using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HandleCreditsButton()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void HandleSettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void HandleBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HandleExitButton()
    {
        Application.Quit();
    }
}
