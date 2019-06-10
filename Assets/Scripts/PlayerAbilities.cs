using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    //General Variables
    public AudioSource aus;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rb;
    private float buttonCoolerA = 0.2f;
    private int buttonCountA = 0;
    private float buttonCoolerD = 0.2f;
    private int buttonCountD = 0;

    //Dash Variables
    public AudioClip dashSound;
    public bool isDashingLeft;
    public bool isDashingRight;
    public float dashDuration;
    public float dashDurationTimer;
    public int distanceToDash;
    public bool canDash;
    public float dashCooldown;
    private float dashTimer;
    private float distance;
    private float dashSpeed = 15f;

    //Guard Variables
    public AudioClip guardSound;
    public AudioClip counterSound;
    public bool guarding;
    public bool gotHit;
    public float guardCooldown;
    private float guardCDTimer;
    public bool canGuard;
    private float guardTimer = 2f;
    private bool hasChanceToCounter;
    private bool missedCounter;
    private float counterTimer = 5f;
    private bool countering;
    private float counterAnimationTimer = 2f;

    //Punch Variables
    public AudioClip punchSound;
    public AudioClip superPunchSound;
    public float superPunchCooldown;
    private float punchCDTimer;
    public bool canSuperPunch = false;
    private float superPunchTimer = 5f;
    private bool superPunchRunning;
    private GameObject leftHand;
    private GameObject rightHand;
    private bool punchLeft = true;
    private bool punchRight = false;
    private bool punching = false;

    private void Start()
    {
        dashDurationTimer = dashDuration;
        punchCDTimer = superPunchCooldown;
        guardCDTimer = guardCooldown;
        dashTimer = dashCooldown;
        leftHand = gameObject.transform.GetChild(1).GetChild(0).gameObject;
        //leftHand = gameObject.transform.Find("Fist1").gameObject;
        rightHand = gameObject.transform.GetChild(1).GetChild(1).gameObject;
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        player = gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !punching)
        {
            aus.clip = punchSound;
            aus.Play();
            HandlePunch();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && canGuard)
        {
            HandleGuarding();
        }

        if(Input.GetKeyDown(KeyCode.C) && !superPunchRunning && canSuperPunch)
        {
            superPunchRunning = true;
            leftHand.GetComponent<Fist>().superPunchActive = true;
            leftHand.GetComponent<SpriteRenderer>().color = new Vector4(255, 0, 0, 255);
            rightHand.GetComponent<Fist>().superPunchActive = true;
            rightHand.GetComponent<SpriteRenderer>().color = new Vector4(255, 0, 0, 255);
        }

        if(superPunchRunning)
        {
            superPunchTimer -= Time.deltaTime;
            if(superPunchTimer <= 0)
            {
                canSuperPunch = false;
                leftHand.GetComponent<Fist>().superPunchActive = false;
                leftHand.GetComponent<SpriteRenderer>().color = leftHand.GetComponent<Fist>().fistColor;
                rightHand.GetComponent<Fist>().superPunchActive = false;
                rightHand.GetComponent<SpriteRenderer>().color = rightHand.GetComponent<Fist>().fistColor;
                superPunchRunning = false;
                superPunchTimer = 5f;
            }
        }

        if(!canGuard)
        {
            guardCDTimer -= Time.deltaTime;
            if(guardCDTimer <= 0)
            {
                canGuard = true;
                guardCDTimer = guardCooldown;
            }
        }

        if(!canDash)
        {
            dashTimer -= Time.deltaTime;
            if(dashTimer <= 0)
            {
                canDash = true;
                dashTimer = dashCooldown;
            }
        }

        if(!canSuperPunch)
        {
            punchCDTimer -= Time.deltaTime;
            if(punchCDTimer <= 0)
            {
                canSuperPunch = true;
                punchCDTimer = superPunchCooldown;
            }
        }

        DashRune();

        //Checks to see if any contradicting booleans are active
        if(anim.GetBool("RightPunch") == true && anim.GetBool("LeftPunch") == true || anim.GetBool("RightPunch") == true && anim.GetBool("StoppedRightPunch") == true || anim.GetBool("StoppedLeftPunch") == true && anim.GetBool("LeftPunch") == true || anim.GetBool("StoppedRightPunch") == true && anim.GetBool("StoppedLeftPunch") == true)
        {
            punchLeft = true;
            punchRight = false;
            punching = false;
            anim.SetBool("RightPunch", false);
            anim.SetBool("LeftPunch", false);
            anim.SetBool("StoppedRightPunch", false);
            anim.SetBool("StoppedLeftPunch", false);
        }

        if (buttonCoolerA >= 0)
        {
            buttonCoolerA -= Time.deltaTime;
        }
        else
        {
            buttonCountA = 0;
        }

        if (buttonCoolerD >= 0)
        {
            buttonCoolerD -= Time.deltaTime;
        }
        else
        {
            buttonCountD = 0;
        }

        //If the player dashed to the left...
        if (isDashingLeft)
        {
            dashDurationTimer -= Time.deltaTime;
            player.GetComponent<PlayerMovement>().canMove = true;
            player.GetComponent<PlayerMovement>().usingAbilities = true;
            rb.velocity = new Vector3(-dashSpeed, 0, 0);

            if (dashDurationTimer <= 0)
            {
                canDash = false;
                isDashingLeft = false;
                player.GetComponent<PlayerMovement>().usingAbilities = false;
                dashDurationTimer = dashDuration;
            }

            if (player.transform.position.x <= distance)
            {
                canDash = false;
                isDashingLeft = false;
                player.GetComponent<PlayerMovement>().usingAbilities = false;
                dashDurationTimer = dashDuration;
            }
        }

        //If the player dashed to the right...
        if(isDashingRight)
        {
            dashDurationTimer -= Time.deltaTime;
            player.GetComponent<PlayerMovement>().canMove = true;
            player.GetComponent<PlayerMovement>().usingAbilities = true;
            if (dashDurationTimer <= 0)
            {
                canDash = false;
                isDashingRight = false;
                player.GetComponent<PlayerMovement>().usingAbilities = false;
                dashDurationTimer = dashDuration;
            }
            rb.velocity = new Vector3(dashSpeed, 0, 0);
            if(player.transform.position.x >= distance)
            {
                canDash = false;
                isDashingRight = false;
                player.GetComponent<PlayerMovement>().usingAbilities = false;
                dashDurationTimer = dashDuration;
            }
        }

        //If the player is guarding...
        if(guarding)
        {
            player.GetComponent<PlayerMovement>().usingAbilities = true;
            anim.SetBool("Guarding", true);
            //If Player Didn't Get Hit
            if (!gotHit)
            {
                guardTimer -= Time.deltaTime;
                if (guardTimer <= 0)
                {
                    guarding = false;
                    anim.SetBool("Guarding", false);
                    guardTimer = 2f;
                    canGuard = false;
                }
            }

            //If Player Got Hit
            if(gotHit)
            {
                anim.SetBool("GotHit", true);
                anim.SetBool("Guarding", false);
                hasChanceToCounter = true;
                if (hasChanceToCounter)
                {
                    counterTimer -= Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        aus.clip = counterSound;
                        aus.Play();
                        guardTimer = 2f;
                        countering = true;
                        anim.SetBool("Countered", true);
                        hasChanceToCounter = false;
                        gotHit = false;
                        guarding = false;
                        canGuard = false;
                        counterTimer = 5f;
                    }

                    if (counterTimer <= 0)
                    {
                        guardTimer = 2f;
                        anim.SetBool("MissedCounter", true);
                        player.GetComponent<PlayerMovement>().usingAbilities = false;
                        hasChanceToCounter = false;
                        gotHit = false;
                        guarding = false;
                        canGuard = false;
                        counterTimer = 5f;
                        //Missed chance to counter
                    }
                }
            }
        }

        //If the player is countering after guarding...
        if(countering)
        {
            counterAnimationTimer -= Time.deltaTime;
            if(counterAnimationTimer <= 0)
            {
                countering = false;
                anim.SetBool("Countered", false);
                anim.SetBool("GotHit", false);
                canGuard = false;
                player.GetComponent<PlayerMovement>().usingAbilities = false;
                counterAnimationTimer = 2f;
            }
        }
    }

    //Triggers the Dash
    void DashRune()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (buttonCoolerA > 0 && buttonCountA == 1 && canDash)
            {
                aus.clip = dashSound;
                aus.Play();
                distance = player.transform.position.x - distanceToDash;
                isDashingLeft = true;
                buttonCountA = 0;
            }
            else
            {
                buttonCoolerA = 0.2f;
                buttonCountA += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (buttonCoolerD > 0 && buttonCountD == 1 && canDash)
            {
                aus.clip = dashSound;
                aus.Play();
                distance = player.transform.position.x + distanceToDash;
                isDashingRight = true;
                buttonCountD = 0;
            }
            else
            {
                buttonCoolerD = 0.2f;
                buttonCountD += 1;
            }
        }
    }

    //Triggers the Guard
    void HandleGuarding()
    {
        anim.SetBool("Guarding", true);
        guarding = true;
        aus.clip = guardSound;
        aus.Play();
    }

    void HandlePunch()
    {
        if(punchLeft)
        {
            anim.SetBool("LeftPunch", true);
            anim.SetBool("StoppedRightPunch", false);
            punchLeft = false;
            punchRight = true;
            punching = true;
        }

        else if(punchRight)
        {
            anim.SetBool("StoppedLeftPunch", false);
            anim.SetBool("RightPunch", true);
            punchLeft = true;
            punchRight = false;
            punching = true;
        }
    }

    void StopPunchingRight()
    {
        anim.SetBool("RightPunch", false);
        anim.SetBool("StoppedRightPunch", true);
        punching = false;
    }

    void StopPunchingLeft()
    {
        anim.SetBool("LeftPunch", false);
        anim.SetBool("StoppedLeftPunch", true);
        punching = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyHitPoint")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyHitPoint")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
