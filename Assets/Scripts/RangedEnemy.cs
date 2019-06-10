using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectileSpawn;
    public float timeBetweenShooting;
    public float projectileForce;
    private float shootTimer;
    private Animator anim;
    private bool animGoing;
    private float animTimer = 0.2f;
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        if(animGoing)
        {
            anim.SetBool("Shooting", true);
            animTimer -= Time.deltaTime;
            if(animTimer <= 0)
            {
                anim.SetBool("Shooting", false);
                animGoing = false;
                animTimer = 0.2f;
            }
        }

        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            animGoing = true;
            GameObject instance = Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-projectileForce, 0));
                gameObject.transform.localEulerAngles = new Vector2(0, 0);
            }

            else if (player.transform.position.x > gameObject.transform.position.x)
            {
                instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(projectileForce, 0));
                gameObject.transform.localEulerAngles = new Vector2(0, 180);
            }
            shootTimer = timeBetweenShooting;
        }
    }
}
