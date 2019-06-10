using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    private float lifeTimer;

    private void Start()
    {
        lifeTimer = lifeTime;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if(lifeTimer <= 0)
        {
            //The projectile despawns
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        Destroy(gameObject);
    }
}
