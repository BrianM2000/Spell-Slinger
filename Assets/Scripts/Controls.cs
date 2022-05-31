using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int maxJumps = 1;
    int currJumps;
    Rigidbody2D rb;
    Transform ts;
    Camera mainCamera; 
    float jumpForce = 10f;
    float HorzMoveForce = 10f;
    bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        ts = GetComponent<Transform>();
        currJumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Jumping logic
        bool onGround = (System.Math.Abs(rb.velocity.y) < 0.0001);

        if(onGround){
            currJumps = maxJumps;
        }

        canJump = onGround || (currJumps > 0);

        float leftRight = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2((leftRight * HorzMoveForce), rb.velocity.y);
        
        //Rotate player
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        bool mouseLeft = transform.position.x - mousePosition.x > 0;

        if(mouseLeft){ //turn left
            ts.rotation = new Quaternion(ts.rotation.x, 0, ts.rotation.z, ts.rotation.w);
        }        
        if(!mouseLeft){ //turn right
            ts.rotation = new Quaternion(ts.rotation.x, 180, ts.rotation.z, ts.rotation.w);
        }

        //Jump
        if(Input.GetKeyDown("space") && canJump){
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            --currJumps;
        }
        
    }
}
