using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingmove : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;

    [Header("Component")]
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    private SpriteRenderer spriteRenderer;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log(Mathf.Abs(rb.velocity.x));
        if(Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }
    }

    private void FixedUpdate() 
    {
        moveCharacter(direction.x);
    }

    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        anim.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        #region Flip
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
        #endregion 
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down *groundLength);
    }

}
