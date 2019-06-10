using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour
{
    public float chaseSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject target;
    [HideInInspector] public bool playerInRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(playerInRange)
        {
            target = player;

            //If the player is to the right...
            if(player.transform.position.x > gameObject.transform.position.x)
            {
                //Move right
                rb.velocity = new Vector2(1, -3) * chaseSpeed;
                gameObject.transform.localEulerAngles = new Vector2(0, 0);
            }

            //If the player is to the left...
            if(player.transform.position.x < gameObject.transform.position.x)
            {
                //Move left
                rb.velocity = new Vector2(-1, -3) * chaseSpeed;
                gameObject.transform.localEulerAngles = new Vector2(0, 180);
            }
        }

        else
        {
            target = null;
            rb.velocity = new Vector3(0, -3, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
        }
    }
}
