using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModCommands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Debug.isDebugBuild)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth = 5;
            }
        }
    }
}
