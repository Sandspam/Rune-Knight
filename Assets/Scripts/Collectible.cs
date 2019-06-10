using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public int shiniesCollected;
    public GameObject[] hearts;
    public AudioSource aus;

    // Start is called before the first frame update
    void Start()
    {
        aus = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth == 5)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
        }

        if (GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth == 4)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
        }

        if (GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth == 3)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
        }

        if (GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth == 2)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
        }

        if (GameObject.Find("Player").GetComponent<PlayerHealthManager>().currentHealth == 1)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
            hearts[3].SetActive(false);
            hearts[4].SetActive(true);
        }
    }

    public void CollectShinie()
    {
        shiniesCollected += 1;
        gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = "" + shiniesCollected;
        aus.Play();
    }
}
