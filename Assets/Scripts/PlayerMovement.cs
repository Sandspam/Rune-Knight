using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3;
    public float sprintSpeed = 6;
    public float JumpForce = 7;
    public bool canMove;
    public bool usingAbilities;
    private Rigidbody2D rb;
    private Animator anim;
    public bool grounded;
    public bool airjump = true;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        Jump();

        if (!usingAbilities)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    canMove = true;
                    rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
                    gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    canMove = true;
                    rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
                    gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    canMove = true;
                    rb.velocity = new Vector3(-sprintSpeed, rb.velocity.y, 0);
                    gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    canMove = true;
                    rb.velocity = new Vector3(sprintSpeed, rb.velocity.y, 0);
                    gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }

        if(!usingAbilities)
        {
            if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                canMove = false;
            }
        }

        if (!canMove)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !grounded && airjump)
        {
            Debug.Log("Jumped Twice");
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * JumpForce);
            airjump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log(airjump);
            Debug.Log("Jumped");
            rb.AddForce(Vector2.up * JumpForce);
            grounded = false;
            Debug.Log(airjump);
        }
    }
}
