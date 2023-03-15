using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MarioSpeed = 5f;
    public float Mariojump = 4.5f;
    public SpriteRenderer spriteRender;
    private GroundSensor Suelosensor;
    private Rigidbody2D rBody;
    float horizontal;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        Suelosensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            spriteRender.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRender.flipX = false;
        }

        if(Input.GetButtonDown("Jump") && Suelosensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * Mariojump, ForceMode2D.Impulse);
        }
        
    }
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * MarioSpeed, rBody.velocity.y);
    }
}
