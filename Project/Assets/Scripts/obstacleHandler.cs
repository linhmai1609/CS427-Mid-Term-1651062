using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleHandler : MonoBehaviour
{
    private int health;
    public GameObject enemyDeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        Debug.Log("hit");
        health -= damage;
        if (health <= 0)
        {
            decease();
        }
    }

    private void decease()
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
