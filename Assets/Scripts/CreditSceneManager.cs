using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleSanderButton()
    {
        SceneManager.LoadScene("SanderCredits");
    }

    public void HandleLeoButton()
    {
        SceneManager.LoadScene("LeoCredits");
    }

    public void HandleJudeButton()
    {
        SceneManager.LoadScene("JudeCredits");
    }

    public void HandleSpencerButton()
    {
        SceneManager.LoadScene("SpencerCredits");
    }

    public void HandleRomanButton()
    {
        SceneManager.LoadScene("RomanCredits");
    }

    public void HandlePerButton()
    {
        SceneManager.LoadScene("PerCredits");
    }
}
