using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool triggerEnd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(triggerEnd)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            triggerEnd = true;
        }
    }

    public void TransferScene ()
    {
        SceneManager.LoadScene("Victory");
    }
}
