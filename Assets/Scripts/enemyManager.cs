using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public Enemy enemy = new Enemy();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            CauseDamage(col.gameObject);
            Debug.Log("Player hit!");
        }
    }

    void CauseDamage(GameObject x)
    {
        x.GetComponent<playerController>().health -= enemy.damage;
    }
}
