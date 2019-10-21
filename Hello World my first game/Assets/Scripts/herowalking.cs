using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herowalking : MonoBehaviour

{
    public Animator animator;

    bool facingRight = true;
    bool grounded = false;
    public Transform groundcheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    float posX, posY;

    public float score = 0;

    public float speed = 10f;
    public float jumpPower = 500f;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;

    }

    //================================================
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        

        float move;
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);
        if ((move < 0) && facingRight)
            Flip();
        else if ((move > 0) && !facingRight)
            Flip();
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rig.AddForce(new Vector2(0, jumpPower));
        }


        animator.SetFloat("speed", Mathf.Abs(move));
                 
    }

    //===========================================
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
            score++;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="enemy")
        {
            rig.position = new Vector3(posX, posY);
            //Destroy(gameObject);
        }
        if(col.gameObject.tag=="axe")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    private void OnGUI()
    {

        GUI.Box(new Rect(0, 0, 100, 20), "score = " + score);

    }
}
