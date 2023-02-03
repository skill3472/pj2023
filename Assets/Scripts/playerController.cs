using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    public Transform hand;

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
        RotateTowardsMouse(hand);
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void OnJump()
    {
        rb.AddForce(Vector2.up * jumpForce);    
    }

    void RotateTowardsMouse(Transform x)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        x.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
    }
    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(hand.position, -hand.right);
        if (hit.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.DrawLine(hand.position, hit.point, Color.red, 2f);
        }
    }
}
