using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public Color fistColor;
    public bool superPunchActive;
    public int damage;

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(superPunchActive)
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage * 2);
            }

            if(!superPunchActive)
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            }
        }
    }
}
