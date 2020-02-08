using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;

    //jumping
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D rgdbody;
    Animator myAnim;
    bool facingRight;
    // Start is called before the first frame update
    void Start() {
        rgdbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = false;
        
    }

    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            rgdbody.AddForce(new Vector2(0, jumpHeight));
        }
    }

    // Update is called once per frame
    void FixedUpdate() {



        //check grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", rgdbody.velocity.y);


        float movement = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(movement));

        rgdbody.velocity = new Vector2(movement*maxSpeed, rgdbody.velocity.y);

        if (movement > 0 && !facingRight)
        {
            flip();
        } else if (movement < 0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
