
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float movespeed;

    public Rigidbody2D rb;
    
    private Vector3 velocity = Vector3.zero;
   
    public bool isJumping;
    
    
    public float JumpForce;

    public Transform groundcheckL;
    public Transform groundcheckR;

    private void Update()
    {
        if(Input.GetButtonDown("Jump")  && IsGrounded)
        {
            isJumping = true;
        }
    } 


    public bool IsGrounded;
    void FixedUpdate()
    {

        IsGrounded = Physics2D.OverlapArea(groundcheckL.position, groundcheckR.position);
        
        
        float horizontalMovement = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        
    }


    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);


        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }
    }




}



