using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputs : MonoBehaviour
{
    private bool pauseToggle;
    private GameObject pauseTrigger;

    // Start is called before the first frame update
    void Start()
    {
        pauseTrigger = gameObject.transform.Find("PauseTrigger").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseToggle)
            {
                Time.timeScale = 0f;
                pauseTrigger.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                pauseToggle = true;
            }

            else if(pauseToggle)
            {
                Time.timeScale = 1f;
                pauseTrigger.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                pauseToggle = false;
            }
        }
    }
}
