using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float HSpeed;
    public float VSpeed;
    public float jumpTime1, jumpTime2, jumpTimeHolder, JumpSpeed;
    public float attackTime, attacktimeHolder;

    public static bool isInCombat;

    public Rigidbody2D rb;

    public BoxCollider2D BC;

    public bool jumping, isAttacking;
    //public bool isInCombat;

    public GameObject SkyBlock, meleeAttack;

    // Start is called before the first frame update
    void Start()
    {
        attacktimeHolder = attackTime;
        isInCombat = false;
        jumpTimeHolder = jumpTime1;
        jumpTime2 = jumpTime1;
    }

    // Update is called once per frame
    void Update()
    {

        
            rb.velocity = new Vector2 (HSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, VSpeed * Input.GetAxis("Vertical"));

        if(rb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (rb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1, 1);
        }

        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            isAttacking = true;
        }

        if(isAttacking == true)
        {
            meleeAttack.SetActive(true);
            attackTime -= Time.deltaTime;
        }

        if(attackTime < 0)
        {
            isAttacking = false;
            meleeAttack.SetActive(false);
            attackTime = attacktimeHolder;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            
            
        }
        if (jumping == true)
        {
            if (jumpTime1 > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                jumpTime1 -= Time.deltaTime;
                SkyBlock.SetActive(false);
            }


            if(jumpTime1 < 0)
            {
                jumpTime2 -= Time.deltaTime;
                rb.velocity = new Vector2(rb.velocity.x, -JumpSpeed);
            }

            if (jumpTime2 < 0)
            {
                
                jumping = false;
                SkyBlock.SetActive(true);
                jumpTime1 = jumpTimeHolder;
                jumpTime2 = jumpTimeHolder;
            }

        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Combat")
        {
            isInCombat = true;
        }
    }

   
    

}
