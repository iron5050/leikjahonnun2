using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        //kóði til að láta player hreyfa sig þegar hann fer til hægri/vinstri
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        //kóði til að restta player animation þegar hann er kjurr
        if (rb.velocity.y == 0)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("jumping", false);
        }

        //ef spilari er á upp leið þá er jumping animation spilað
        if (rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }

        //if (Input.GetKey(KeyCode.Space)){
        //    anim.SetBool("jumping", true);
        //}

        //ef spilari er á niður leið þá er falling animation spilað
        if (rb.velocity.y < 0) {
            anim.SetBool("Falling", true);
            anim.SetBool("jumping", false);
        }
        
    }
   // private bool IsGrounded()
   // {
        //float extraHegitText = .01f;
        //Physics2D.Raycast(CircleCollider2D.bounds.center, Vector2.down, CircleCollider2D.bounds.extens.y + extraHegitText);
    //}
}
