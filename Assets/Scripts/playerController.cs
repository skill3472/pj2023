using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }

    void MoveUpdate()
    {
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            OnJump();
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    void OnJump()
    {
        rb.AddForce(Vector2.up * jumpForce);    
    }
}
