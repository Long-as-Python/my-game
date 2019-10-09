using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herowalking : MonoBehaviour

{
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
        float move;
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jumpPower));
        }
    }
}
