using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herowalking : MonoBehaviour

{
    bool facingRight = true;
    bool grounded = false;
    public Transform groundcheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    public float speed = 10f;
    public float jumpPower = 500f;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        float move;
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rig.AddForce(new Vector2(0, jumpPower));
        }

        if ((move < 0) && facingRight)
            Flip();
        else if ((move > 0) && !facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.GetComponent<CircleCollider2D>().tag == "coin")
        {
            Destroy(col.gameObject);
        }
    }
}
