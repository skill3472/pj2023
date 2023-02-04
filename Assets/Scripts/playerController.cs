using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    public float manaCost = 10;
    public float manaRechargeSpeed = 0.1f;
    public Transform hand;
    [Space] 
    public float damage;
    public float mana = 100;
    public float health = 100;
    [Space] 
    public Slider hpbar;
    public Slider mpbar;
    public GameObject deathScreen;
    public audioManager am;

    private float timer = 0;

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
        ManaRecharge();
        UIUpdate();
        DeathCheck();
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
        if (mana >= manaCost)
        {
            am.Play("Shoot");
            mana -= manaCost;
            RaycastHit2D hit = Physics2D.Raycast(hand.position, -hand.right);
            if (hit.collider.gameObject.GetComponent<enemyManager>().enemy != null)
            {
                Enemy enem = hit.collider.gameObject.GetComponent<enemyManager>().enemy;
                enem.health -= damage;
                Debug.DrawLine(hand.position, hit.point, Color.red, 2f);

            }
        }
    }

    void ManaRecharge()
    {
        timer += Time.deltaTime;
        if (timer > manaRechargeSpeed && mana < 100)
        {
            timer = 0;
            mana++;
        }
    }
    
    void UIUpdate()
    {
        hpbar.value = health / 100;
        mpbar.value = mana / 100;
    }

    void DeathCheck()
    {
        if (health <= 0f)
        {
            deathScreen.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
