using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private bool isFacingRight = true;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //Moving

        animator.SetFloat("Speed", Mathf.Abs(horizontal)); //Animation

        if(Input.GetButtonDown("Jump") && IsGrounded()){ //Jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        float verticalVelocity = rb.velocity.y;
        animator.SetFloat("VerticalVelocity", verticalVelocity);
        
        Flip();
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //On the Ground
    }

    private void Flip(){ //Left or Right
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
