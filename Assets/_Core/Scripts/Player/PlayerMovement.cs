using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    private float horizontalVal;
    public float speed;
    public float jumpForce;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GroundCheck groundCheck;
    private bool facingRight = true;
    private bool moveBlock=false;
    public FloatingJoystick joystick;

    public void BlockMove(bool _block){
        moveBlock = _block;
    }

    public void StopMove(){
        rigidbody2D.velocity = Vector2.zero;
    }

    public void DamageForce(){
        if(facingRight){
            rigidbody2D.AddForce(new Vector2(-50,300));
        }else{
            rigidbody2D.AddForce(new Vector2(50,300));
        }
    }

    void Update()
    {
        if (moveBlock){return;}
        // Debug.Log("Player Movement - Update");
        Move();
        Jump();
        Flip();
        animator.SetFloat("Speed",Mathf.Abs(horizontalVal));
    }

    private void Flip(){
        if ((horizontalVal < 0 && facingRight) || (horizontalVal>0 && !facingRight))
        {
            facingRight = !facingRight;
            // spriteRenderer.flipX = !facingRight;    

            transform.Rotate(0,180,0);
        }
    }

    public void Jump()
    {
        if (!groundCheck.isGrounded){return;}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();    
        }
    }

    public void DoJump(){
        if (!groundCheck.isGrounded){return;}
        animator.SetBool("isJumping", true);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
    }
    
    public void OnJumpClick(){
        DoJump();
    }

    public void OnLandEvent(){
        animator.SetBool("isJumping", false);
    }

    private void Move()
    {
        // -1 = Iquierda
        //  1 = Derecha
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        // horizontalVal = Input.GetAxisRaw("Horizontal");
        horizontalVal=joystick.Horizontal;
        rigidbody2D.velocity = new Vector2(horizontalVal * speed, rigidbody2D.velocity.y);
    }
}
