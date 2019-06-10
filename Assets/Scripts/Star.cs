using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float starLifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        starLifetime -= Time.deltaTime;

        if(starLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
